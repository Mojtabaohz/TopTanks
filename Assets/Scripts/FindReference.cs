using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindReference : MonoBehaviour
{

    public GameObject[] objectsToFind;
    //private int[] filledStatus;
    public GameObject button;
    public int filledSlot;


    


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
