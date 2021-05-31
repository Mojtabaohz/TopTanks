﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = System.Random;

/// <summary>
/// The vehicle that will do battle. This is the same for every participant in the arena.
/// Its 'brains' will be found on the TankInfo
/// </summary>
public class TankController : MonoBehaviour
{
    private float distanceToTarget;
    public int fireRange = 100;
    private bool loaded = false;
    //public bool active = false;
    
    /*
     * TurretAim variables
     */
    private TurretAim turretAim = null;
    private bool isIdle = false;
    
    
    private const float reloadTime = 2;
    //public Transform spawnPoint;
    //TODO: Get position from the menu spot and assign it here before spawn, need to code, Spawn() function
    //and instantiate the model of the tank in the position
    
    


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
    public GameObject[] enemiesList = null;
    /// <summary>
    /// the AI that will control this Tank. Is set by TankInfo.
    /// </summary>
    private BaseAI ai = null;

    // create a level playing field. Every Tank has the same basic abilities
    private float TankSpeed = 10.0f;
    private float SeaSize = 50.0f;
    private float RotationSpeed = 180.0f;

    // Start is called before the first frame update
    void Start()
    {
        turretAim = gameObject.GetComponent<TurretAim>();
        ai = gameObject.AddComponent<AiScout>();
        SetAI(ai);
 
        //active = true;
        navAgent.speed = TankSpeed;
        navAgent.angularSpeed = RotationSpeed;
        navAgent.stoppingDistance = 30;
        enemiesList = GameObject.FindGameObjectsWithTag("Enemy");
        ReloadBullet();
        StartBattle();
    }

    public void Update()
    {
        ReloadBullet();
        
        if (target == null)
            turretAim.isIdle = target == null;
        else
            turretAim.aimPosition = target.position;
        
    }

    
    /// <summary>
    /// Assigns the AI that steers this instance
    /// </summary>
    /// <param name="_ai"></param>
    public void SetAI(BaseAI _ai) {
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
    /// Tell this ship to start battling
    /// Should be called only once
    /// </summary>
    public void StartBattle() {
        //Debug.Log("Battle starts");
        StartCoroutine(ai.RunAI());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

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

    void DistanceDetection(){
        distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
    }
    /// <summary>
    /// Move this ship ahead by the given distance
    /// </summary>
    /// <param name="distance">The distance to move</param>
    /// <returns></returns>
    public IEnumerator __Ahead(float distance) {
        int numFrames = (int)(distance / (TankSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++) {
            transform.Translate(new Vector3(0f, 0f, TankSpeed * Time.fixedDeltaTime), Space.Self);
            Vector3 clampedPosition = Vector3.Max(Vector3.Min(transform.position, new Vector3(SeaSize, 0, SeaSize)), new Vector3(-SeaSize, 0, -SeaSize));
            transform.position = clampedPosition;

            yield return new WaitForFixedUpdate();            
        }
    }
    
    public IEnumerator __MoveToTarget(Transform target)
    {
        DistanceDetection();
        if (distanceToTarget > fireRange)
        {
            navAgent.isStopped = false;
            navAgent.SetDestination(target.position);
            yield return new WaitForFixedUpdate();
        }
        else
        {
            navAgent.isStopped = true;
        }
        
    }

    /// <summary>
    /// Move the ship backwards by the given distance
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
    /// Turns the ship left by the given angle
    /// </summary>
    /// <param name="angle">The angle to rotate</param>
    /// <returns></returns>
    public IEnumerator __TurnLeft(float angle) {
        int numFrames = (int)(angle / (RotationSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++) {
            transform.Rotate(0f, -RotationSpeed * Time.fixedDeltaTime, 0f);

            yield return new WaitForFixedUpdate();            
        }
    }

    /// <summary>
    /// Turns the ship right by the given angle
    /// </summary>
    /// <param name="angle">The angle to rotate</param>
    /// <returns></returns>
    public IEnumerator __TurnRight(float angle) {
        int numFrames = (int)(angle / (RotationSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++) {
            transform.Rotate(0f, RotationSpeed * Time.fixedDeltaTime, 0f);

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
            Debug.Log("fire");
            loaded = false;
            GameObject projectile = Instantiate(BulletPrefab);
            Physics.IgnoreCollision(projectile.GetComponent<Collider>(), emitter.parent.parent.GetComponent<Collider>());
            projectile.transform.position = emitter.position;
            Vector3 rotation = projectile.transform.rotation.eulerAngles;
            projectile.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
            projectile.GetComponent<Rigidbody>().AddForce(emitter.forward * 50, ForceMode.Impulse);
            Destroy(projectile, 2.0f);
            
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

    /// <summary>
    /// Turn the sensor to the left by the given angle
    /// </summary>
    /// <param name="angle">The angle to rotate</param>
    /// <returns></returns>
    public IEnumerator __TurretLookAt(Transform target)
    {
        //Turret.transform.rotation = Quaternion.LookRotation(target.position);
        
        Turret.transform.LookAt(target);
        yield return new WaitForFixedUpdate();
    }
    
}
