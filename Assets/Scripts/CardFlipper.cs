using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardFlipper : MonoBehaviour,IPointerDownHandler
{
    public float x, y, z;
    public GameObject cardBack;
    public GameObject cardFace;
    public bool cardBackIsActive;
    private int timer;

    public void Start()
    {
        cardFace.SetActive(true);
        cardBack.SetActive(false);
    }



    public void StartFlip()
    {
        StartCoroutine(Flipper());
    }

    private void Flip()
    {
        Debug.Log("flipper card");
        if (!cardBackIsActive)
        {
            cardBack.SetActive(true);
            cardFace.SetActive(false);
            cardBackIsActive = false;
        }
        else
        {
            cardBack.SetActive(false);
            cardFace.SetActive(true);
            cardBackIsActive = true;
        }
    }

    IEnumerator Flipper()
    {
        for (int i = 0; i < 180; i++)
        {
            yield return new WaitForSeconds(0.001f);
            transform.Rotate(new Vector3(x,y,z));
            timer++;
            //Debug.Log(timer);
            if (timer == 90 || timer == -90)
            {
                Flip();
            }
        }
        timer = 0;
    }

    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        StartCoroutine(Flipper());
    }
}
