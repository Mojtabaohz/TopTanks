using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel : MonoBehaviour
{
   private SpriteRenderer _spriteRenderer;
   //public Sprite Tank;
   //public Sprite TankInfo;
   public bool cardindex = true;

   public void ToggleFace(bool showFace)
   {
      if (!showFace)
      {
         _spriteRenderer.sprite = Tank;
         cardindex = true;
         //TODO: show front of card
      }
      else
      {
         _spriteRenderer.sprite = TankInfo;
         cardindex = false;
         //TODO: show back of card
      }
   }

   private void Awake()
   {
      _spriteRenderer = GetComponent<SpriteRenderer>();
   }
}
