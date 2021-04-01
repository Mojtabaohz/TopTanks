using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public TankInfo card;

    public Text nameText;

    public Text descriptionText;

    public Image artworkImage;

    public Text DamageText;

    public Text healthText;

    public Text armorText;
    private SpriteRenderer _spriteRenderer;

    public GameObject face;

    public GameObject back;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.name;
        descriptionText.text = card.description;
        artworkImage.sprite = card.artwork;
        DamageText.text = card.damage.ToString();
        healthText.text = card.health.ToString();
        armorText.text = card.armor.ToString();
        face.SetActive(true);
        back.SetActive(false);
    }
    
    public bool cardindex = true;

    public void ToggleFace(bool showFace)
    {
        if (!showFace)
        {
            _spriteRenderer.sprite = face.GetComponent<Sprite>();
            cardindex = true;
            //TODO: show front of card
        }
        else
        {
            _spriteRenderer.sprite = back.GetComponent<Sprite>();
            cardindex = false;
            //TODO: show back of card
        }
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
