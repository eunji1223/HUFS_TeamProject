using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlien : Alien
{
    [SerializeField]
    private int maxChildAlien;
    private int BossAlienHP;

    //Boss Rocation , division Rocation Control , Child object
    private Vector2 spawnPoint;
    public float ControlPosition = 0.5f;
    public GameObject ChildAlien;

    protected override void Start()
    {
        base.Start();
        BossAlienHP = 4;
        maxChildAlien = 4;
    }


    public override void TakeDamage(int damage)
    {
        BossAlienHP -= damage;

        if (BossAlienHP <= 0)
        {
            // spawnPoint = new Vector2(transform.position.x, transform.position.y + ControlPosition);
            SplitIntoSmallMonsters();
            Die();
        }

    }
    private void SplitIntoSmallMonsters()
    {
        for (int i = 0; i < maxChildAlien; i++)
        {
            spawnPoint = new Vector2(transform.position.x + i, transform.position.y + ControlPosition);
            GameObject smallMonster = Instantiate(ChildAlien, spawnPoint, Quaternion.identity);
            smallMonster.GetComponent<BossChildAlien>().SetBossAlien(this);
        }
    }


}
