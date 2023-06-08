using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnMouseDown()
    {
        int num = Random.Range(4, 7);
        CoinManager.instance.IncreaseCoin(num);
        gameObject.SetActive(false);
        CoinManager.instance.coinActiveCount -= 1;
    }
}
