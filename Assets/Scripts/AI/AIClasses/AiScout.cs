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
    
    public override IEnumerator RunAI() {
        while (true)
        {
            if (Tank.target)
            {
                //Debug.Log(Tank.GetComponent<HealthBar>().currentHealth);
                yield return MoveToTarget(Tank.target);
                //Debug.Log("move to target", Tank.target);
                //yield return TurretLookAt(Tank.target);
                yield return Fire();

            }
            else
            {
                LookForNewTarget();
                
            } 
        }

    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override void OnScannedRobot(ScannedRobotEvent e)
    {
        Debug.Log("Tank detected: " + e.Name + " at distance: " + e.Distance + " target " + e.Transform);
        if (!targetName.Contains(e.Name))
        {
            targetName.Add(e.Name);
            targetDistance.Add(e.Distance);
            targetTransform.Add(e.Transform);
            Debug.Log("Tank detected: " + e.Name + " at distance: " + e.Distance + " target " + e.Transform);
            Tank.target = e.Transform;
        }
    }

    private void LookForNewTarget()
    {
        if (Tank.target)
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
