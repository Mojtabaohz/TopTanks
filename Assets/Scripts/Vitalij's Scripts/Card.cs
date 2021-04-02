using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
   public new string name;

   public Sprite artwork;

   public int rank;
   public int defence;
   public int mobility;
   public int power;

   public void Print () {
       Debug.Log(name + ": " + rank + " The Defence is: " + defence);
   }
}
