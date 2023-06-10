using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossChildAlien : Alien
{
    private BossAlien bossAlien;
    
    protected override void Start()
    {
        base.Start();
    }

    public void SetBossAlien(BossAlien boss)
    {
        bossAlien = boss;
    }
}
