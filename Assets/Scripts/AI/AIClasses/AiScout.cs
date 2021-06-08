using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Random=UnityEngine.Random;


public class AiScout : BaseAI
{


    public Transform mainTarget;
    public List<String> targetName = new List<String>();
    public List<float> targetDistance = new List<float>();
    public List<Transform> targetTransform = new List<Transform>();

    

    private void FindTarget(bool ally)
    {
        if (ally)
        {
            int rnd = Random.Range(0, Tank.enemiesList.Length);
            mainTarget = Tank.enemiesList[rnd].transform;
        }
        else
        {
            int rnd2 = Random.Range(0, Tank.friendList.Length);
            mainTarget = Tank.friendList[rnd2].transform;
        }
        
    }
    public void Update()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            if (mainTarget)
            {
                MoveToTarget(mainTarget);
                Fire();
            }
            else
            {
                FindTarget(false);
            } 
        }
        else
        {
            if (mainTarget)
            {
                MoveToTarget(mainTarget);
                Fire();
            }
            else
            {
                FindTarget(true);
            } 
        }
        
        
            
                
                //Debug.Log(Tank.GetComponent<HealthBar>().currentHealth);
                //Debug.Log("move to target", Tank.target);
                //yield return TurretLookAt(Tank.target);
                //LookForNewTarget();

    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override void OnScannedRobot(ScannedRobotEvent e)
    {
        //Debug.Log("Tank detected: " + e.Name + " at distance: " + e.Distance + " target " + e.Transform);
        if (!targetName.Contains(e.Name))
        {
            targetName.Add(e.Name);
            targetDistance.Add(e.Distance);
            targetTransform.Add(e.Transform);
            //Debug.Log("Tank detected: " + e.Name + " at distance: " + e.Distance + " target " + e.Transform);
            Tank.target = e.Transform;
        }
    }

    private void LookForNewTarget()
    {
        if (!Tank.target)
        {
            mainTarget = Tank.target;
        }
        else
        {
            WonderAround();
        }
    }

    private void WonderAround()
    {
        int rnd = Random.Range(0, Tank.enemiesList.Length);
        //Debug.Log(rnd);
        //Debug.Log(Tank.enemiesList[rnd]);
        Tank.target = Tank.enemiesList[rnd].transform;
    }
}
