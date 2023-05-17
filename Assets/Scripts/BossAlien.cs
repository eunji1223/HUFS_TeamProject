using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlien : Alien
{
    private int BossAlienHP;
    private Rigidbody2D BossAlienRb;
    private Vector2 BossAlienMoveDirection;
    private int maxChildAlien;

    //분열 할 몬스터 변수// 보스 사망위치 , 분열 위치 조정 , 자식 오브젝트
    private Vector2 spawnPoint;
    public float ControlPosition = 0.5f;
    public GameObject ChildAlien;

    protected override void Start()
    {
        base.Start();
        BossAlienMoveDirection = Vector2.left;
        BossAlienHP = 3;
        maxChildAlien = 4;
    }
    void Update()
    {
        transform.Translate(BossAlienMoveDirection * moveSpeed * Time.deltaTime);

        BossAlienRb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("plant"))
        {
            BossAlienMoveDirection = Vector2.zero;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("plant"))
        {
            BossAlienMoveDirection = Vector2.left;
        }
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
            spawnPoint = new Vector2(transform.position.x+i, transform.position.y + ControlPosition);
            GameObject smallMonster = Instantiate(ChildAlien, spawnPoint, Quaternion.identity);
            smallMonster.GetComponent<BossChildAlien>().SetBossAlien(this);
        }
    }


}
