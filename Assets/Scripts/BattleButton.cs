using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class BattleButton : MonoBehaviour
{

    public GameObject[] objectsToFind;
    public GameObject button;
    public int filledSlot;


    public float sceneTimer;
    public void Update()
    {
        sceneTimer += Time.deltaTime;
        
    }


    public void CheckSlot()
    {
        filledSlot = 0;
        foreach (var slot in objectsToFind)
        {
            filledSlot += slot.transform.childCount;
        }
        CheckStartButton();

    }

    private void CheckStartButton()
    {
        if (filledSlot >= 3)
        {
            button.SetActive(true);
            AnalyticsResult timeSpent = Analytics.CustomEvent("Time to complete the hand" + sceneTimer);
            Debug.Log("Analytics Result"+ timeSpent +" : "+ sceneTimer );
        }
        else
        {
            button.SetActive(false);
        }
    }
    // public void OpenButton()
    // {
    //     if(transform.childCount > 0 )
    //     {
    //         Button.SetActive(true);
    //     }
    // }
}
