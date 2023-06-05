using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

using Debug = UnityEngine.Debug;

public class Spawner : MonoBehaviour, IDropHandler
{
    public static Spawner instance { get; private set; }

    public AstronautSO astronautSO;
    public GameObject[] character;

    public CoinManager coinManager;

    private void Awake()
    {
        instance = this;
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {

       var item = DragHandeler.itemBeingDragged;
       if (item != null)
       {
                for (int i = 0; i < astronautSO.astronautItems.Length; i++)
                {
                    if (astronautSO.astronautItems[i].name == item.name)
                    {
                        //Debug.Log(itemSO[i].name);
                        character[i].GetComponent<Astronaut>().AllocateItem(astronautSO.astronautItems[i]);
                        int cost = astronautSO.astronautItems[i].cost;
                        coinManager.DecreaseCoin(cost);
                        Instantiate(character[i], new Vector3(-8, 0, 0), transform.rotation);
                    }
                        
                }
       }
        
    }
}