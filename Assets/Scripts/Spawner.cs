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

    [SerializeField]
    private GameObject[] character;
    [SerializeField]
    private AstronautItem[] AstronautSO;

    CoinManager coinManager;

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
                for (int i = 0; i < AstronautSO.Length; i++)
                {
                    if (AstronautSO[i].name == item.name)
                    {
                        //Debug.Log(itemSO[i].name);
                        Instantiate(character[i], new Vector3(-8, 0, 0), transform.rotation);
                        character[i].GetComponent<Astronaut>().AllocateItem(AstronautSO[i]);
                    }
                    int num = 0;
                    coinManager.DecreaseCoin(num);
                }
       }
        
    }
}