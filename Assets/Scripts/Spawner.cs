using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawner : MonoBehaviour, IDropHandler
{
    public GameObject character;

    public void OnDrop(PointerEventData eventData)
    {
        var item = DragHandeler.itemBeingDragged;
        if (item != null)
        {
            Instantiate(character, new Vector3(-8, 0, 0), transform.rotation);
        }
    }
}