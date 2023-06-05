using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance { get; private set; }
    private int coin = 0;

    void Awake() => instance = this;

    private float CoinX;
    private float CoinY;
    [SerializeField]
    private float WaitTime = 20.0f;
    private float timer = 0;
    [SerializeField]
    private GameObject CoinPre;
    private int LimitCoin = 10;
    [SerializeField]
    private TMP_Text coinText;
    private GameObject[] coins = new GameObject[10];
    public int coinActiveCount = 0;

    private void Start()
    {
        // CoinInitialCreate();
    }

    private void Update()
    {
        if (coinActiveCount < 10)
        {
            timer += Time.deltaTime;
            if (timer > WaitTime)
            {
                RandomCoinAvailable();
                timer = 0;
            }
        }
    }

    private void CoinInitialCreate()
    {
        for (int i = 0; i < coins.Length; i++)
        {
            GameObject coin = Instantiate(CoinPre);
            coin.gameObject.SetActive(false);
            coins[i] = coin;
            coin.transform.parent = GameObject.Find("CoinArr").transform;
        }
    }

    private void RandomCoinAvailable()
    {
        // -6 <= x <= 6, -2 <= y <= 2
        CoinX = Random.Range(-8.0f, 8.0f);
        CoinY = Random.Range(-3.0f, 3.0f);
        for (int i = 0; i < coins.Length; i++)
        {
            if (coins[i].gameObject.activeSelf == false)
            {
                coins[i].gameObject.SetActive(true);
                coins[i].gameObject.transform.position = new Vector2(CoinX, CoinY);
                coinActiveCount += 1;
                return;
            }
        }
    }


    public int Coin
    {
        get { return coin; }
        set { coin = value; }
    }

    public void IncreaseCoin(int num)
    {
        coin += num;
        SetCoinText(coin);
    }

    public void DecreaseCoin(int num)
    {
        coin -= num;
        SetCoinText(coin);
    }


    private void SetCoinText(int coins)
    {
        coinText.text = coins.ToString();
    }
}
