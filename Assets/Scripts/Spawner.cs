using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class Spawner : MonoBehaviour, IDropHandler
{
    public static Spawner instance { get; private set; }

    void Awake() => instance = this;

    [SerializeField]
    private GameObject character;
    [SerializeField]
    private Item[] itemSO;

   // public static bool spawnerCondition = true; 

    public void OnDrop(PointerEventData eventData)
    {

       var item = DragHandeler.itemBeingDragged;
       if (item != null)
       {
                for (int i = 0; i < itemSO.Length; i++)
                {
                    if (itemSO[i].name == item.name)
                    {
                        GetComponent<Astronaut>().AllocateItem(itemSO[i]);
                        Instantiate(itemSO[i].AstroPre, new Vector3(-8, 0, 0), transform.rotation);
                    }
                }
       }
        
    }
}