using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCode : MonoBehaviour
{
    private CardFlipper _cardFliper;
    private CardModel _cardModel;
    private bool cardIndex = true;
    public GameObject card;

    private void Awake()
    {
        _cardModel = card.GetComponent<CardModel>();
        _cardFliper = card.GetComponent<CardFlipper>();
    }


    private void OnGUI()
    {
        if (GUI.Button(new Rect(10,10,100,28),"Hit Me!"))
        {
            if (cardIndex )
            {
                //_cardFliper.FlipCard(_cardModel.Tank,_cardModel.TankInfo);
                cardIndex = false; 
                Debug.Log(1);
            }
            else
            {
                //_cardFliper.FlipCard(_cardModel.TankInfo,_cardModel.Tank);
                cardIndex = true;
                Debug.Log(2);
            }
        }
    }
}
