using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using  UnityEngine.EventSystems;
using UnityEngine.UI;

public class TanksToBattle : MonoBehaviour,IHasChanged
{
    [SerializeField] private Transform slots;
    //[SerializeField] private Card tankInSlot;
    [SerializeField] private Text cardText;
    public void Start()
    {
        UpdateTankList();
    }


    public void UpdateTankList()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append(" - ");
        foreach (Transform slotTransform in slots)
        {
            GameObject item = slotTransform.GetComponent<CardSlot>().item;
            if (item)
            {
                builder.Append(item.GetComponent<CardDisplay>().card.name);
                builder.Append(" - ");
                FindObjectOfType<Manager>().battleTanks.Add(item.GetComponent<CardDisplay>().card);
            }
        }
        cardText.text = builder.ToString();
    }
}

namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void UpdateTankList();

    }
    
}
