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
    
/// <summary>
/// Find a target base on the AI side
/// </summary>
    private void FindTarget()
    {
        if (gameObject.CompareTag("Player"))
        {
            int rnd = Random.Range(0, Tank.enemiesList.Count);
            if (Tank.enemiesList.Count>0)
            {
                mainTarget = Tank.enemiesList[rnd].transform;
                    Tank.target = mainTarget;
            }
            
        }
        else
        {
            int rnd2 = Random.Range(0, Tank.friendList.Count);
            if (Tank.friendList.Count>0)
            {
                
                    mainTarget = Tank.friendList[rnd2].transform;
                    Tank.target = mainTarget;

            }
            
        }
        
    }
    public void Update()
    {
        
        //When AI does not have target will update the list of tanks and find a target
        if (!mainTarget)
        {
            //Debug.Log("find a new target");
            //Tank.turretAim.IsIdle = mainTarget == null;
            Tank.UpdateTankList();
            FindTarget();
            
        }
        //When AI have the target it will Aim and move towards it
        else
        {
            //Debug.Log("Move to target");
            MoveToTarget(mainTarget);
            Fire();
            //Tank.turretAim.AimPosition = mainTarget.position;
        }

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

    

    private void WonderAround()
    {
        int rnd = Random.Range(0, Tank.enemiesList.Count);
        //Debug.Log(rnd);
        //Debug.Log(Tank.enemiesList[rnd]);
        Tank.target = Tank.enemiesList[rnd].transform;
    }
}
