using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    private int AlienHP;
    private Vector2 moveDirection = Vector2.left;


    [SerializeField]
    private float Attacktimer;
    private float timer;
    private bool InAttackRange = false;

    private Rigidbody2D rb;
    public GameObject astronaut;
    public GameObject AlienAttack;

    private Collider attackRangeCollider;


    protected virtual void Start()
    {
        attackRangeCollider = GetComponentInChildren<Collider>();
    }

    public void SetHP(int newHP)
    {
        AlienHP = newHP;
    }

    public void SetMoveSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    public void SetAttackTimer(float newAttackTimer)
    {
        Attacktimer = newAttackTimer;
    }


    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        rb = GetComponent<Rigidbody2D>();

        timer += Time.deltaTime;

    }

    public virtual void TakeDamage(int damage)
    {
        AlienHP -= damage;

        if (AlienHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Astronaut"))
        {
            InAttackRange = true;
            moveDirection = Vector2.zero;

            if (timer >= Attacktimer)
            {
                spawnAlienAttack();
                timer = 0;
            }
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Astronaut"))
        {
            InAttackRange = false;
            moveDirection = Vector2.left;
        }
    }
    private void spawnAlienAttack()
    {
        Instantiate(AlienAttack, transform.position, transform.rotation);
    }

}
