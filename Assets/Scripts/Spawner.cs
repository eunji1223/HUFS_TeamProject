using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.EventSystems;

using Debug = UnityEngine.Debug;

public class Spawner : MonoBehaviour, IDropHandler
{
    public static Spawner instance { get; private set; }

    [SerializeField]
    private AstronautSO astronautSO;
    [SerializeField]
    private GameObject PositionObject;


    //private bool onDrag = DragHandeler.drag; 

    private void Awake()
    {
        instance = this;

    }

    public void OnDrop(PointerEventData eventData)
    {
        int cost;
        var item = DragHandeler.itemBeingDragged;
        for (int i = 0; i < astronautSO.astronautItems.Length; i++)
        {
            if (astronautSO.astronautItems[i].name == item.name)
            {
                cost = astronautSO.astronautItems[i].cost;
                if (CoinManager.instance.Coin >= cost && item != null)
                {
                    CoinManager.instance.DecreaseCoin(cost);
                    Instantiate(astronautSO.astronautItems[i].Prefab, PositionObject.transform.position, transform.rotation);
                }
            }
        }

    }              
                  
}