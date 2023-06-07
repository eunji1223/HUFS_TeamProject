using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;


public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 startPosition;
    public static GameObject itemBeingDragged;
    Transform startParent;

    public AstronautSO astronautSO;

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
      
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        for (int i = 0; i < astronautSO.astronautItems.Length; i++)
        {
            Debug.Log(astronautSO.astronautItems[i].name);
            if (astronautSO.astronautItems[i].name == itemBeingDragged.name)
            {   
                int cost = astronautSO.astronautItems[i].cost;
                if (CoinManager.instance.Coin >= cost)
                { 
                    transform.position = eventData.position;
                }
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(startParent);
        transform.localPosition = Vector3.zero;
        itemBeingDragged = null;
    }
}


