using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
 
  
    void Update()
    {
        if (Input.GetButtonDown("Switch1"))
        {
            cam1.setActive(true);
        
            // cam1.getComponent<CameraTarget>
            // cam2.setActive(false);
        }
        if (Input.GetButtonDown("Switch2"))
        {
            // cam1.setActive(false);
            // cam2.setActive(true);
        }
    }
}
