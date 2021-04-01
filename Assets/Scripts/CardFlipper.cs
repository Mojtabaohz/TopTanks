using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlipper : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private CardDisplay _model;

    public AnimationCurve scaleCurve;
    public float duration = 0.5f;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _model = GetComponent<CardDisplay>();
    }

    public void FlipCard(Sprite startImage, Sprite endImage)
    {
        StopCoroutine(Flip(startImage,endImage));
        StartCoroutine(Flip(startImage, endImage));
    }

    IEnumerator Flip(Sprite startImage, Sprite endImage)
    {
        _spriteRenderer.sprite = startImage;
        
        float time = 0;
        while (time <= 1f)
        {
            float scale = scaleCurve.Evaluate(time);
            time += Time.deltaTime / duration;

            Vector3 localScale = transform.localScale;
            localScale.x = scale;
            transform.localScale = localScale;

            if (time >= 0.5f)
            {
                _spriteRenderer.sprite = endImage;
            }

            yield return new WaitForFixedUpdate();
        }
    }
}
