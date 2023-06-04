using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class Alien : MonoBehaviour
{

    private AlienItem alienItem;
    private bool isAttacking = false;
    
    public int moveSpeed;
    private int health;

    [SerializeField]
    private float Attacktimer;
    private float timer;
    private bool InAttackRange = false;

    private Collider attackRangeCollider;

    protected virtual void Start()
    {
        health = alienItem.health;
        attackRangeCollider = GetComponentInChildren<Collider>();
    }

    void Update()
    {

        if (InAttackRange) {
            Stop();
            Attack();
        }
        else {
            Move();
        }

        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        timer += Time.deltaTime;

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Move() {
        moveSpeed = alienItem.moveSpeed;
    }

    private void Stop() {
        moveSpeed = 0;
    }

    private protected virtual void Die() {
        Destroy(gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Astronaut"))
        {
            InAttackRange = true;
            Stop();

            if (timer >= Attacktimer)
            {
                // CreateAttack();
                timer = 0;
            }
        }
    }

    protected void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Astronaut"))
        {
            InAttackRange = false;
            Move();
        }
    }

    private void Attack() {

        if (!isAttacking) {
            StartCoroutine("CreateAttack", alienItem);
        }
    }
    
    private void CreateAttack(AlienItem alienItem)
    {
        alienItem.AttackPrefab.GetComponent<AlienAttack>().SetAttack(alienItem);
        Instantiate(alienItem.AttackPrefab, transform.position, transform.rotation);
    }

}
