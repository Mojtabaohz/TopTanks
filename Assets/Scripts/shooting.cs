using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bulletEmitter;
    public Transform emitter;
    public float bulletLifeTime = 2f;
    public GameObject bullet;
    public GameObject playerBase;
    public int dmg;
    public float bulletSpeed = 1f;
    public bool loaded = true;
    //public int ammoCount = 0 ;
    public float reloadSpeed = 4;
    protected float Timer;
    protected float buffTimer;
    public bool Buff;
    public float buffDuration;
    //public GameObject shootSign;
    //public AudioSource ShootSound;
    //public AudioSource ReloadSound;
    //public AudioSource UziSound;
    //public AudioSource SniperSound;
    public float moveSpeed;
    public float MS = 4f;
    // Start is called before the first frame update
    void Start()
    {
       loaded = false;
    }

    // Update is called once per frame
    void Update()
    {
        Reload(loaded); 
        BuffCheck(Buff);
    }
    public void Shoot(){
        
        Shooting();
        //Debug.Log("shoot called");
    }

    void Shooting(){
        if(loaded){
            Unload();
            GameObject TemporaryBullethandler;
            TemporaryBullethandler = gameObject.transform.GetChild((gameObject.transform.childCount-1)).gameObject;
            TemporaryBullethandler.transform.parent = null;
            TemporaryBullethandler.GetComponent<Rigidbody>().useGravity = true;
            TemporaryBullethandler.GetComponent<Rigidbody>().detectCollisions = true;
            //Instantiate(bullet,bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;

            TemporaryBullethandler.transform.Rotate(Vector3.left * 90);

            Rigidbody TempRigidbody;
            TempRigidbody = TemporaryBullethandler.GetComponent<Rigidbody>();
            TempRigidbody.AddForce(transform.forward * (bulletSpeed + moveSpeed));
            if(bullet.name == "bullet" || bullet.name == "Bomb"){
                TempRigidbody.AddForce(transform.up *  (250));
            }
            
            
            Destroy(TemporaryBullethandler, 6.0f);
                if (bulletSpeed<=1500){
                    //ShootSound.Play(); 
                }
                else if (bulletSpeed <= 2000) {
                    //UziSound.Play();
                } else {
                    //SniperSound.Play();
                }                
            }
            else{

                //print("shooting is on cooldown");
                //ReloadSound.Play();
            }
    }
    
    public void Shooting2(){
        if(loaded){
            Unload();
            GameObject projectile = Instantiate(bullet);
            Physics.IgnoreCollision(projectile.GetComponent<Collider>(), emitter.parent.parent.GetComponent<Collider>());
            projectile.transform.position = emitter.position;
            Vector3 rotation = projectile.transform.rotation.eulerAngles;
            projectile.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
            projectile.GetComponent<Rigidbody>().AddForce(emitter.forward * bulletSpeed, ForceMode.Impulse);
            Destroy(projectile, 2.0f);
                            
        }
        else{

            //print("shooting is on cooldown");
            //ReloadSound.Play();
        }
    }
    
    /*
     * Fire Method to experiment
     */
    public void Fire()
    {
        GameObject projectile = Instantiate(bullet);
        //Physics.IgnoreCollision(projectile.GetComponent<Collider>(), emitter.parent.GetComponent<Collider>());
        projectile.transform.position = emitter.position;
        Vector3 rotation = projectile.transform.rotation.eulerAngles;
        projectile.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        projectile.GetComponent<Rigidbody>().AddForce(emitter.forward * bulletSpeed, ForceMode.Impulse);
        StartCoroutine(DestroyProjectile(projectile,bulletLifeTime));
    }
 
    private IEnumerator DestroyProjectile (GameObject projectile, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(projectile);
    }

    void Reload(bool _loaded){
        if(!_loaded){
            Timer += Time.deltaTime;
            if(Timer >= reloadSpeed){
                Timer = 0; 
                //if(ammoCount < 0){
                    //BulletInstantiate(gameObject.GetComponent<Collider>());
                //}
                //else if(ammoCount>0){
                    //BulletInstantiate(gameObject.GetComponent<Collider>());
                    //ammoCount -= 1;
                //}
                //else if(ammoCount == 0 ){
                    //SetDefaultWeapon(this.gameObject);
                    //BulletInstantiate(gameObject.GetComponent<Collider>());
                    //ammoCount -= 1;
                //}
                loaded = true;
                //shootSign.SetActive(true);
            }
        }
        else{
            return;
        }
    }

    void BuffCheck(bool _buff){
        if(_buff){
        buffTimer += Time.deltaTime;
            if(buffTimer >= buffDuration){
                buffTimer = 0;
                moveSpeed = MS;
                Buff = false;
            }
        }
    }

    

    public void BulletInstantiate(Collider obj){
        if(!loaded){
            Timer = 0 ;
            if(gameObject.transform.childCount < 4){
                GameObject TemporaryBullet;
                TemporaryBullet = Instantiate(bullet, obj.GetComponent<shooting>().bulletEmitter.transform.position, obj.GetComponent<shooting>().bulletEmitter.transform.rotation) as GameObject;
                TemporaryBullet.transform.Rotate(Vector3.left * 90);
                TemporaryBullet.transform.parent = obj.GetComponent<shooting>().transform;
                TemporaryBullet.GetComponent<Rigidbody>().useGravity = false;
                TemporaryBullet.GetComponent<Rigidbody>().detectCollisions = false;
            }
        }
    }

    public void DestroyCurrentBullet(GameObject currentBullet){
        Destroy(currentBullet);
    }

    public void Unload(){
        loaded = false;
        //
        //shootSign.SetActive(false);
        

    }
   
}
