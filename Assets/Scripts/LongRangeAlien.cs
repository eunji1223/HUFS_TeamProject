using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LongRangeAlien : Alien
{
    //공격 범위// Collider
    private Collider attackRangeCollider;

    private int longRangeAlienHP;
    private Vector2 longRangeAlienMoveDirection;
    private Rigidbody2D longRangeAlienRb;
    //public AlienData alienData;
    
    public float attackRangeSize=2.0f;

    protected override void Start()
    {
        base.Start();
        longRangeAlienMoveDirection = Vector2.left;
        attackRangeCollider = GetComponentInChildren<Collider>();

        /*
        Vector3 attackRangeSize = attackRangeCollider.bounds.size;
        attackRangeSize.x = attackRangeSize;
        attackRangeCollider.transform.localScale = attackRangeSize;
        */
    }

    void Update()
    {
        transform.Translate(longRangeAlienMoveDirection * moveSpeed * Time.deltaTime);

        longRangeAlienRb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("plant"))
        {
            longRangeAlienMoveDirection = Vector2.zero;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("plant"))
        {
            longRangeAlienMoveDirection = Vector2.left;
        }
    }
}
