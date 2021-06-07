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
    public Text scoreText;

    public Image artworkImage;

    public Text attackDamageText;

    public Text healthText;

    public Text movementSpeedText;

    public Text armorText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = card.score.ToString();
        nameText.text = card.name;
        descriptionText.text = card.description;
        artworkImage.sprite = card.artwork;
        attackDamageText.text = card.attackDamage.ToString();
        movementSpeedText.text = card.movementSpeed.ToString();
        healthText.text = card.baseHealth.ToString();
        armorText.text = card.armor.ToString();
        CheckRarity();
    }

    private void CheckRarity()
    {
        if (card.tankRarity == TankInfo.TankRarity.Common)
        {
            
        }
    }
}
