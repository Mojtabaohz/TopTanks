using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlot : MonoBehaviour,IDropHandler
{
    public GameObject item
    {
        get
        {
            if (transform.childCount>0)
            {
                return transform.GetChild(0).gameObject;
            }

            return null;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if (!item)
        {
            
            DragDrop.itemBeingDragged.transform.SetParent(transform);
            ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x, y) => x.UpdateTankList());
            FindObjectOfType<FindReference>().CheckSlot();
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
            //    GetComponent<RectTransform>().anchoredPosition;
        }
        
    }
}
