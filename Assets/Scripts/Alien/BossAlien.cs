using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlien : Alien
{
    [SerializeField]
    private int maxChildAlien;

    //Boss Rocation , division Rocation Control , Child object
    private Vector2 spawnPoint;
    public GameObject ChildAlien;

    protected override void Start()
    {
        base.Start();
        maxChildAlien = 6;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (health <= 0)
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
            spawnPoint = new Vector2(transform.position.x + i, transform.position.y-0.5f);
            GameObject smallMonster = Instantiate(ChildAlien, spawnPoint, Quaternion.identity);
            smallMonster.GetComponent<BossChildAlien>().SetBossAlien(this);
        }
    }


}
