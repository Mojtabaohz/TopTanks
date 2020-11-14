using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllerAI : MonoBehaviour
{
    [Header("Navigation")]
    [SerializeField]
    private NavMeshAgent navAgent;
    [SerializeField]
    private GameObject m_Target;
    //[SerializeField]
    //private Animation m_TargetAnimation;
    [SerializeField]
    private float viewRange;
    [SerializeField]
    private float m_DistanceToTarget; //I am using this variable to see in realtime what the distance is between the characters when the scene is played. This is so that I can tweak my stopping distance and weapon throw distance in the future functions
    [SerializeField]
    private GameObject m_HomeBase;
    [Space(8)]
    [SerializeField]
    private float m_Health = 20f;
    [SerializeField]
    private float m_RetreatHealth = 5f;
    //[SerializeField]
    //private GameObject m_BulletPrefab;
    [SerializeField]
    private float fireRange = 15f;
     //The character needs to know when to start the weapon attack, so I use this as the range within the BulletAttack() function

    //[SerializeField]
    //private float m_BulletAttackRate = 2; //How often should the weapons fire. This can be adjusted per character, and I have set it to every 2 “seconds” for now.

    //[SerializeField]
    //private float m_BulletAttackTracker = 0; //This variable has a timer functionality, and deltaTime gets added to this variable in the BulletAttack() function. As soon as m_BulletAttackTracker is equal or greater than m_BulletAttackRate(currently 2), it will reset the value for m_BulletAttackTracker timer back to 0

    RaycastHit hit ;
    
    // Start is called before the first frame update
    void Start()
    {
        fireRange = gameObject.GetComponent<TanksAttr>().fireRange;
        viewRange = gameObject.GetComponent<TanksAttr>().viewRange;
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        
        
        DistanceDetection();
        if((gameObject.GetComponent<HealthBar>().currentHealth > m_RetreatHealth) ){
            gameObject.GetComponent<NavMeshAgent>().stoppingDistance = fireRange;
            MoveToTarget();
        }
        
    }
    
    void DistanceDetection(){
        this.m_DistanceToTarget = Vector3.Distance(this.transform.position, this.m_Target.transform.position);
    }

    void MoveToTarget(){
        
        if(fireRange < m_DistanceToTarget){
            navAgent.SetDestination(m_Target.transform.position);
        }
        else
        {
            
            gameObject.GetComponent<shooting>().Shoot();
        }
        

    }
    

}
