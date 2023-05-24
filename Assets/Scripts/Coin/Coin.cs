using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    CoinManager coinManager;
    private void Awake()
    {
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
    }
    private void OnMouseDown()
    {
        int num = Random.Range(4, 7);

        coinManager.IncreaseCoin(num);
        gameObject.SetActive(false);
        CoinManager.instance.coinActiveCount -= 1;
    }
}
