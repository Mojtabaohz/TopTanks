using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random=UnityEngine.Random;

/// <summary>
/// The vehicle that will do battle. This is the same for every participant in the arena.
/// Its 'brains' will be found on the TankInfo
/// </summary>
public class TankController : MonoBehaviour
{
    //Tank info data
    private int attackDamage = 20;
    private int shellVelocity = 150;
    private float distanceToTarget;
    public int fireRange = 100;
    private bool loaded = false;
    public bool tankListUpdateBool = true;
    public AudioSource ShootingSound;
    
    /*
     * TurretAim variables
     */
    public TurretAim turretAim = null;
    private bool isIdle = false;
    //[FormerlySerializedAs("TargetPoint")] public Transform targetPoint = null;
    
    
    private const float reloadTime = 2;
    //public Transform spawnPoint;
    //TODO: Get position from the menu spot and assign it here before spawn, need to code, Spawn() function
    //and instantiate the model of the tank in the position
    
    public ParticleSystem muzzleFlash;


    protected float Timer;
    // the bullets and the locations on the prefab where they spawn from
    public GameObject BulletPrefab = null;
    public Transform emitter = null;
    //public Transform CannonLeftSpawnPoint = null;
    //public Transform CannonRightSpawnPoint = null;

    // the 'scanner' that allows the tank to 'see' its surroundings
    public GameObject Turret = null;

    // states can be used to indicate the state of the ship (attacking, fleeing, searching etc.)
    public GameObject[] states = null;
    // navmesh agent to access functions for finding new target and moving patterns
    public NavMeshAgent navAgent = null;
    public Transform target = null;
    public  List<GameObject> redList = new List<GameObject>();
    public List<GameObject> blueList = new List<GameObject>();
    /// <summary>
    /// the AI that will control this Tank. Is set by TankInfo.
    /// </summary>
    private BaseAI ai = null;

    // create a level playing field. Every Tank has the same basic abilities
    private float TankSpeed = 10.0f;
    private float SeaSize = 50.0f;
    private float RotationSpeed = 180.0f;

    // particle systems activated during combat
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        turretAim = gameObject.GetComponent<TurretAim>();
        target = gameObject.transform;
        ai = gameObject.AddComponent<AiScout>();
        SetAI(ai);
        
        //active = true;
        navAgent.speed = TankSpeed;
        navAgent.angularSpeed = RotationSpeed;
        navAgent.stoppingDistance = 30;

        UpdateTankList();
        ReloadBullet();
    }

    
    
    public void UpdateTankList()
    {
        if (tankListUpdateBool)
        {
            foreach (GameObject tanks in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                redList.Add(tanks);
            }
            //enemiesList = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject tanks in GameObject.FindGameObjectsWithTag("Player"))
            {
                blueList.Add(tanks);
            }

            tankListUpdateBool = false;
            //friendList = GameObject.FindGameObjectsWithTag("Player"); 
        }
        else
        {
            foreach (GameObject redTank in redList.ToList())
            {
                if (!redTank.gameObject.activeSelf)
                {
                    redList.Remove(redTank);
                }
            }
            foreach (GameObject blueTank in blueList.ToList())
            {
                if (!blueTank.gameObject.activeSelf)
                {
                    redList.Remove(blueTank);
                }
            }
        }
            
            
    }
    public void Update()
    {
        //Debug.DrawRay(emitter.position, emitter.transform.forward * emitter.transform.position.magnitude, Color.red);
        ReloadBullet();
        
        if (!target)
            turretAim.isIdle = target == null;
        else
        {
            turretAim.aimPosition = target.position;
        }
            
    }

    
    /// <summary>
    /// Assigns the AI that steers this instance
    /// </summary>
    /// <param name="_ai"></param>
    private void SetAI(BaseAI _ai) {
        ai = _ai;
        ai.Tank = this;
    }
    /// <summary>
    /// reload the bullet after firing
    /// </summary>
    private void ReloadBullet()
    {
        if (!loaded)
        {
            Timer += Time.deltaTime;
            if (Timer >= reloadTime)
            {
                Timer = 0;
                loaded = true;
            }
        }
    }
/*
    public void Respawn()
    {
        
            //Debug.Log("tank respawned");
            GameObject tank = Instantiate(gameObject, gameObject.GetComponent<TankController>().spawnPoint.position,
                gameObject.GetComponent<TankController>().spawnPoint.rotation);
            TankController TankController = tank.GetComponent<TankController>();
            TankController.SetAI(new MojiAI());
            
    }
    */
    

    

    /// <summary>
    /// If a tank is inside the 'scanner', its information (distance and name) will be sent to the AI
    /// 
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            ScannedRobotEvent scannedRobotEvent = new ScannedRobotEvent();
            scannedRobotEvent.Distance = Vector3.Distance(transform.position, other.transform.position);
            scannedRobotEvent.Name = other.name;
            scannedRobotEvent.Transform = other.transform;
            ai.OnScannedRobot(scannedRobotEvent);
        }
    }
    /// <summary>
    /// Calculate the distance between current game object and the target
    /// </summary>
    /// <param name="target"> chosen target that the AI will chose based on its algorithms</param>
    void DistanceDetection(Transform target){
        distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
    }
    /// <summary>
    /// Move this tank ahead by the given distance
    /// </summary>
    /// <param name="distance">The distance to move</param>
    /// <returns></returns>
    public void __Ahead(float distance) {
        
        transform.Translate(new Vector3(0f, 0f, TankSpeed * Time.fixedDeltaTime), Space.Self);
        Vector3 clampedPosition = Vector3.Max(Vector3.Min(transform.position, new Vector3(SeaSize, 0, SeaSize)), new Vector3(-SeaSize, 0, -SeaSize));
        transform.position = clampedPosition;

                       
        
    }
    
    public void __MoveToTarget(Transform target)
    {
        DistanceDetection(target);
        if (distanceToTarget > fireRange)
        {
            navAgent.isStopped = false;
            navAgent.SetDestination(target.position);
            
        }
        else
        {
            navAgent.isStopped = true;
        }
        
    }

    /// <summary>
    /// Move the tank backwards by the given distance
    /// </summary>
    /// <param name="distance">The distance to move</param>
    /// <returns></returns>
    public IEnumerator __Back(float distance) {
        int numFrames = (int)(distance / (TankSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++) {
            transform.Translate(new Vector3(0f, 0f, -TankSpeed * Time.fixedDeltaTime), Space.Self);
            Vector3 clampedPosition = Vector3.Max(Vector3.Min(transform.position, new Vector3(SeaSize, 0, SeaSize)), new Vector3(-SeaSize, 0, -SeaSize));
            transform.position = clampedPosition;

            yield return new WaitForFixedUpdate();            
        }
    }

    
    /// <summary>
    /// Sit and hold still for one (fixed!) update
    /// </summary>
    /// <returns></returns>
    public IEnumerator __DoNothing() {
        yield return new WaitForFixedUpdate();
    }

    /// <summary>
    /// Fire from the forward pointing cannon
    /// </summary>
    /// <param name="power">???</param>
    /// <returns></returns>
    public void __Fire() {
        if (loaded)
        {
            loaded = false;
            //Debug.Log("fire"+gameObject);
            //Debug.DrawRay(emitter.transform.position,emitter.transform.forward* emitter.transform.position.magnitude,Color.red,1f);
                // if(muzzleFlash)
                // {
                //     muzzleFlash.Play();
                // }
                muzzleFlash.Play();
                ShootingSound.Play();
                RaycastHit hit;
                if (target != null)
                {
                    if (Physics.Raycast(emitter.transform.position, emitter.transform.forward, out hit,fireRange))
                    {
                        //Debug.Log(hit.transform.name);
                
                        HealthBar hitTarget = hit.transform.GetComponent<HealthBar>();
                        if (hitTarget != null)
                        {
                            hitTarget.TakeDamage(attackDamage);
                        }
                        
                        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                        Destroy(impactGO, 2f);

                    }
                }
                
            /*
        GameObject projectile = Instantiate(BulletPrefab);
        projectile.transform.position = emitter.position;
        //Debug.Log("<color=blue>emitter</color>" + emitter.position);
        Physics.IgnoreCollision(projectile.GetComponent<Collider>(), emitter.parent.parent.GetComponent<Collider>());
        projectile.transform.forward = emitter.transform.forward;
        Vector3 rotation = projectile.transform.rotation.eulerAngles;
        projectile.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        projectile.GetComponent<Rigidbody>().AddForce(emitter.forward * shellVelocity, ForceMode.Impulse);
        Destroy(projectile, 2.0f);
        */
            
        }
        
    }

    

    /// <summary>
    /// Change the color of the states (for vanity or visualising state)
    /// </summary>
    /// <param name="color"></param>
    public void __SetColor(Color color) {
        foreach (GameObject state in states) {
            state.GetComponent<MeshRenderer>().material.color = color;
        }
    }

    
    
    
}
