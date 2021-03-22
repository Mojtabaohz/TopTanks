using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionButtonAppear : MonoBehaviour
{

    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    public void OpenButton()
    {
        if(Button1 != null || Button2 != null || Button3 != null)
        {
            Button1.SetActive(true);
            Button2.SetActive(true);
            Button3.SetActive(true);
        }
    }
}
