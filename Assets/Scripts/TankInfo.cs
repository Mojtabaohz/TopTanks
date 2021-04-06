using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new TankCard", menuName = "TankCard")]
public class TankInfo : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite artwork;

    public int power;
    public int health;
    public int defence;
    public int mobility;
    
    
}
