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
        StartCoroutine(DelayCall(45f));
    }
    private IEnumerator DelayCall(float time)
    {
        yield return new WaitForSeconds(time);
        EndGame();
        
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
