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
            if (Tank.redList.Count>0)
            {
                int rnd = Random.Range(0, Tank.redList.Count);
                mainTarget = Tank.redList[rnd].transform;
                Tank.target = mainTarget;
            }
            
        }
        else
        {
            if (Tank.blueList.Count>0)
            {
                int rnd2 = Random.Range(0, Tank.blueList.Count);
                mainTarget = Tank.blueList[rnd2].transform;
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
            //Tank.turretAim.isIdle = mainTarget == null;
            Tank.UpdateTankList();
            FindTarget();
            
        }
        
        else if (!mainTarget.gameObject.activeSelf)
        {
            Tank.UpdateTankList();
            FindTarget();
        }
        //When AI have the target it will Aim and move towards it
        else
        {
            //Debug.Log("Move to target");
            MoveToTarget(mainTarget);
            Fire();
            Tank.target = mainTarget;
            Debug.Log("update torret position");
            //Tank.turretAim.aimPosition = mainTarget.position;
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

    


}
