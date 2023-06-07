using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

using Debug = UnityEngine.Debug;

public class Spawner : MonoBehaviour, IDropHandler
{
    public static Spawner instance { get; private set; }

    [SerializeField]
    private AstronautSO astronautSO;

    private void Awake()
    {
        instance = this;
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
                        GameObject astronautPrefab = astronautSO.astronautItems[i].Prefab.GetComponent<Astronaut>().gameObject;
                        if (astronautPrefab != null) {
                            astronautPrefab.AllocateItem(astronautSO.astronautItems[i]);
                            
                            int cost = astronautSO.astronautItems[i].cost;
                            CoinManager.instance.DecreaseCoin(cost);
                            Instantiate(astronautPrefab, transform.position, transform.rotation);

                        }
                        
                    }
                        
                }
       }
        
    }
}