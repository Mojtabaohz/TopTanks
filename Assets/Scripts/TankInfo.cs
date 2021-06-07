using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "new TankCard", menuName = "TankCard")]
public class TankInfo : ScriptableObject
{
    //[Header("General Info")]
    public enum TankClass
    {
        LT,MT, HT, TD, SPG
    }

    public enum TankRarity
    {
        Common, Rare, Epic
    }
    [Header("General Info")]
    public TankClass tankClass;

    public TankRarity tankRarity;
    public new string name;
    public string description;
    public int score;
    public Sprite artwork;
    public GameObject initialPrefab;
    [Header("Power")]
    public int attackDamage;

    public int reloadTime;
    public int peneteration;
    [Header("Defense")]
    public int baseHealth;

    public int armor;
    [Header("Mobility")] 
    public int turretRotationSpeed;

    public int tankRotationSpeed;
    public int movementSpeed;
    
    
    
}

