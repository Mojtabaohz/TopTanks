using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public TankInfo card;

    public Text nameText;

    public Text descriptionText;

    public Image artworkImage;

    public Text powerText;

    public Text healthText;

    public Text mobilityText;

    public Text defenceText;
    
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.name;
        descriptionText.text = card.description;
        artworkImage.sprite = card.artwork;
        powerText.text = card.power.ToString();
        mobilityText.text = card.mobility.ToString();
        healthText.text = card.health.ToString();
        defenceText.text = card.defence.ToString();
        
    }

    

    
}
