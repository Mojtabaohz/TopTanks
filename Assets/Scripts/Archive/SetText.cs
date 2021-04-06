using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SetText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text result;
    public GameObject tapScreen;
    private float timer = 0;
    private float delay = 3.0f;
    void Start()
    {
        tapScreen.SetActive(false);
        Invoke("DisplayText",3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > delay){            
            if(Input.anyKey){
            SceneManager.LoadScene("CardDeck");
            Debug.Log("activate the text");
            }
        }
        
        
    }

    void DisplayText(){
        tapScreen.SetActive(true);
    }
}
