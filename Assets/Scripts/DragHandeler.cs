using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

using Image = UnityEngine.UI.Image;


public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 startPosition;
    public static GameObject itemBeingDragged;
    public static bool drag;
    Transform startParent;

    [SerializeField]
    private AstronautSO astronautSO;

    private static Color color;
    private int cost;



    void Start()
    {
        drag = false;
        color = gameObject.GetComponent<Image>().color;
        color.a = 0.5f;
        gameObject.GetComponent<Image>().color = color;

        itemBeingDragged = gameObject;
        for (int i = 0; i < astronautSO.astronautItems.Length; i++)
        {
            if (astronautSO.astronautItems[i].name == itemBeingDragged.name)
            {
                cost = astronautSO.astronautItems[i].cost;
            }
        }
    }
    void Update()
    {
        if (CoinManager.instance.Coin >= cost)
        {
            drag = true;
            color.a = 1;
            gameObject.GetComponent<Image>().color = color;
        }
        else if (CoinManager.instance.Coin < cost)
        {
            drag = false;
            color.a = 0.5f;
            gameObject.GetComponent<Image>().color = color;
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (CoinManager.instance.Coin >= cost)
        {
            transform.position = Input.mousePosition;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(startParent);
        transform.localPosition = Vector3.zero;
        itemBeingDragged = null;
    }
}

