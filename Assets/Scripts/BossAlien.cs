using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlien : Alien
{
    private int BossAlienHP;
    private int maxChildAlien;

    //분열 할 몬스터 변수// 보스 사망위치 , 분열 위치 조정 , 자식 오브젝트
    private Vector2 spawnPoint;
    public float ControlPosition = 0.5f;
    public GameObject ChildAlien;

    protected override void Start()
    {
        base.Start();
        BossAlienHP = 3;
        maxChildAlien = 4;
    }


    public override void TakeDamage(int damage)
    {
        BossAlienHP -= damage;

        if (BossAlienHP <= 0)
        {
            spawnPoint = new Vector2(transform.position.x, transform.position.y + ControlPosition);
            SplitIntoSmallMonsters();
            Destroy(gameObject);

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
