using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public TankCard card;

    public Text nameText;

    public Text descriptionText;

    public Image artworkImage;

    public Text DamageText;

    public Text healthText;

    public Text armorText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.name;
        descriptionText.text = card.description;

        artworkImage.sprite = card.artwork;
        DamageText.text = card.damage.ToString();
        healthText.text = card.health.ToString();
        armorText.text = card.armor.ToString();
    }
    
}
