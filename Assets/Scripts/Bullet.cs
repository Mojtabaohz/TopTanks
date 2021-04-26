using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    public int bulletSpeed = 100;
    public int dmg =  5;
    //public bool damageOverTime = false;
    //public float damageInterval = 1f;
    //public float damageOverTimeDuration = 2f;


    void FixedUpdate()
    {
        //transform.Translate(new Vector3(0f, 0f, bulletSpeed * Time.fixedDeltaTime), Space.Self);
        
    }

    
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag.Equals("Enemy"))
        {
            DoDamage(dmg,other);
            Debug.Log("Damage Done");
            gameObject.SetActive(false);
            DoDamage(dmg,other);
        }
        Destroy(gameObject);
        
    }


    void DoDamage(int damage, Collider other){
        //if(damageOverTime){
        //    DoDamageOverTime(damageOverTimeDuration);
        //}
        if(other.gameObject.GetComponent<HealthBar>()){
            other.gameObject.GetComponent<HealthBar>().TakeDamage(damage);
        }
        //Debug.Log("destroy bullet");
        Destroy(gameObject,0.1f);
                    
    }

    
       
    //void DoDamageOverTime(float duration){
        //float durationCounter = 0;
       // while(durationCounter<duration){
            //InvokeRepeating("DoDamage",0.5f,damageInterval);
            //durationCounter++;
        //}
        
    //}
}
