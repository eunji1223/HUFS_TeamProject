using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance { get; private set; }
    private int coin = 0;

    void Awake() => instance = this;

    public void SetCoin(int num)
    {
        coin += num;
    }
    public int GetCoin()
    {
        return coin;
    }
}
