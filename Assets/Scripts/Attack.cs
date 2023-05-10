using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float speed;
    public float range;
    public float size;
    public AttackType attackType;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        transform.localScale = new Vector3(size, size, size);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(attackType);
        }
        Destroy(gameObject);
    }
}
