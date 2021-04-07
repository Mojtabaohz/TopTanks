using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindReference : MonoBehaviour
{

    public GameObject ObjectToFind;
    public GameObject Button;
    
    bool isDone = false;
    

    // Update is called once per frame
    void Update()
    {
        if (!isDone) {
        ObjectToFind = transform.GetChild(0).gameObject;
        
        Debug.Log(ObjectToFind.name);

        isDone = true;
        if (transform.childCount > 0) {
            Button.SetActive(true);
        }
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
