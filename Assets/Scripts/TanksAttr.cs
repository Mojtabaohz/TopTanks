using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanksAttr : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Tank attributes")]
    [SerializeField]
    public float damage;
    
    [SerializeField]
    public float penetration;
    
    [SerializeField]
    public float moveSpeed;
    
    [SerializeField]
    public float health;
    
    [SerializeField]
    public float currentHealth;
    
    [SerializeField]
    public float viewRange;
    
    [SerializeField]
    public float fireRange;
    
    [SerializeField]
    public float armor;
   
    [SerializeField]
    public float reloadSpeed;
    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
