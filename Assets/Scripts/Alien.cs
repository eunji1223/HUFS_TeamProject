using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    private int HP = 5;
    private int AlienHP;
    public float moveSpeed = 3;
    public int attack = 1;
    private Vector2 moveDirection;

    private Rigidbody2D rb;

    public GameObject Astronaut;


    protected virtual void Start()
    {
        gameObject.tag = "Alien";
        AlienHP = HP;
        moveDirection = Vector2.left;
    }


    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        rb = GetComponent<Rigidbody2D>();
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
            moveDirection = Vector2.zero;
            collision.GetComponent<Astronaut>().TakeDamage(attack);
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Astronaut"))
        {
            moveDirection = Vector2.left;
        }
    }

}
