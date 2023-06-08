using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField]
    private AlienSO alienSO;
    [SerializeField]
    private int alienID;
    private AlienItem myAlien;

    [SerializeField]
    private LayerMask targetLayermask;

    private int health;
    private int moveSpeed;
    private bool isAttacking = false;
    private Vector2 moveDirection = Vector2.left;

    private float timer;
    private bool InAttackRange = false;
    private Animator AlienAnim;



    public Animator GetAlienAnim
    {
        get { return AlienAnim; }
    }

    protected virtual void Start()
    {
        AlienAnim = GetComponent<Animator>();
        myAlien = alienSO.alienItems[alienID];
        
        health = myAlien.health;
        moveSpeed = myAlien.moveSpeed;
        timer = 0;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, myAlien.attackRange, targetLayermask);
        if (hit.collider != null)
        {
            Stop();
            Attack();
        }
        else
        {
            Move();
        }

        /* moveSpeed = 0: Stop, !0: Move */
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    protected void Move()
    {
        moveSpeed = myAlien.moveSpeed;
        AlienAnim.SetBool("isMoving", true);
    }

    protected void Stop()
    {
        moveSpeed = 0;
        AlienAnim.SetBool("isMoving",false);
    }

    protected void Die()
    {
        Destroy(gameObject);
    }


    private void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            StartCoroutine("CreateAttack");
            AlienAnim.SetBool("isAttack",true);

        }
    }

    private IEnumerator CreateAttack()
    {
        Instantiate(myAlien.AttackPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z-1), transform.rotation);
        
        // Wait for a short duration before allowing another attack
        yield return new WaitForSeconds(myAlien.attackSpeed);
        isAttacking = false;
    }

    // protected void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Astronaut"))
    //     {
    //         InAttackRange = true;
    //         moveDirection = Vector2.zero;

    //         if (timer >= myAlien.attackSpeed)
    //         {
    //             createAlienAttack();
    //             timer = 0;
    //         }
    //     }
    // }

    // protected void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Astronaut"))
    //     {
    //         InAttackRange = false;
    //         moveDirection = Vector2.left;
    //     }
    // }

}
