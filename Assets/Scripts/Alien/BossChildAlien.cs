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
}
