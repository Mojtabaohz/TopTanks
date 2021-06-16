using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    // public void camSwitchButton() { 

    public void switchCam() {
        if(cam1.gameObject.activeSelf)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
        else{
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
    }

    // void Update()
    //     {
    //         if (Input.GetButtonDown("Switch1"))
    //         {
    //             cam1.SetActive(true);
    //             cam2.SetActive(false);
    //         }
    //         if (Input.GetButtonDown("Switch2"))
    //         {
    //             cam1.SetActive(false);
    //             cam2.SetActive(true);
    //         }
    //     }
    }
