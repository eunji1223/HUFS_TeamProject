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
    void Awake() => instance = this;

    [SerializeField]
    private GameObject[] character;
    [SerializeField]
    private Item[] itemSO;

    public void OnDrop(PointerEventData eventData)
    {

       var item = DragHandeler.itemBeingDragged;
       if (item != null)
       {
                for (int i = 0; i < itemSO.Length; i++)
                {
                    if (itemSO[i].name == item.name)
                    {
                        Debug.Log(itemSO[i].name);
                        Instantiate(character[i], new Vector3(-8, 0, 0), transform.rotation);
                        character[i].GetComponent<Astronaut>().AllocateItem(itemSO[i]);
                    }
                }
       }
        
    }
}