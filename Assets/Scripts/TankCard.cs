using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new TankCard", menuName = "TankCard")]
public class TankCard : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite artwork;

    public int damage;
    public int health;
    public int armor;
    
    
}
