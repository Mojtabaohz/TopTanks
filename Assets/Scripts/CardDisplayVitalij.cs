using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplayVitalij : MonoBehaviour
{

    public Card card;

    public Text nameText;

    public Image artworkImage;

    public Text rankText;
    public Text defenceText;
    public Text powerText;
    public Text mobilityText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.name;

        artworkImage.sprite = card.artwork;
        
        rankText.text = card.rank.ToString();
        defenceText.text = card.defence.ToString();
        powerText.text = card.power.ToString();
        mobilityText.text = card.mobility.ToString();
    }

    
}
