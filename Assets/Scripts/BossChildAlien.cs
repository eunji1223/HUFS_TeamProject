using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossChildAlien : Alien
{
    private BossAlien bossAlien;
    private int BossChildAlienHP;
    protected override void Start()
    {
        base.Start();
        BossChildAlienHP = 3;
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
            Debug.Log("Astronaut's Attack");
            Destroy(gameObject);
        }
    }
}
