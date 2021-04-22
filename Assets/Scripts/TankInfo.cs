using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "new TankCard", menuName = "TankCard")]
public class TankInfo : ScriptableObject
{
    
    public enum TankClass
    {
        LT,MT, HT, TD, SPG
    }

    public TankClass tankClass;
    public new string name;
    public string description;
    public Sprite artwork;

    public int power;
    public int health;
    public int defence;
    public int mobility;
    public GameObject initialPrefab;
    
}

