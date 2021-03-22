using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonAppear : MonoBehaviour
{

    public GameObject Button;

    public void OpenButton()
    {
        if(Button != null )
        {
            Button.SetActive(true);
        }
    }
}
