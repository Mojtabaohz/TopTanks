using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    [Header("Detected Enemies")]
    [SerializeField]
    public List<GameObject> spottedEnemies = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetEnemyList();
    }
    
     
}
