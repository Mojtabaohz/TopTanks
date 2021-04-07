using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonAppear : MonoBehaviour
{

    public GameObject Button;

    public void OpenButton()
    {
        if(transform.childCount > 0 )
        {
            Button.SetActive(true);
        }
    }
}
