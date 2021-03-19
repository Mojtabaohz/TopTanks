using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResultManager : MonoBehaviour
{
    public GameObject player01;
    
    public GameObject player02;
    public int score;
    
    protected float Timer;
    protected float ChaosTimer;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(score >= 3){//base was here
            EndGame();
        }
        
       
        //SpawnBox();
        //ChaosSpawner();
        
    }

    void EndGame(){
        SceneManager.LoadScene("ResultScene");
    }
    
    
}
