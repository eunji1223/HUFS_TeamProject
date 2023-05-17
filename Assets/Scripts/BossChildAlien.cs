using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossChildAlien : Alien
{
    private BossAlien bossAlien;
    private int BossChildAlienHP;
    private Vector2 BossChildAlienMoveDirection;

    //public AlienData alienData;
    protected override void Start()
    {
        base.Start();
        BossChildAlienHP = 3;
        BossChildAlienMoveDirection=Vector2.left;
    }
    public void SetBossAlien(BossAlien boss)
    {
        bossAlien = boss;
    }
    public override void TakeDamage(int damage)
    {
        BossChildAlienHP -= damage;

        if (BossChildAlienHP <= 0)
        {
            Debug.Log("Plant's Attack");
            Destroy(gameObject);
        }
    }
}
