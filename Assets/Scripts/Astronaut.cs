using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Debug = UnityEngine.Debug;

public class Astronaut : MonoBehaviour
{
    private AstronautItem myAstronaut;
    private int health;
    private int moveSpeed; // 0: Stop, !0: Move
    private bool isAttacking;

    [SerializeField]
    private LayerMask layermask;
    [SerializeField]
    private AstronautSO astronautSO;
    [SerializeField]
    private int characterIndex;
    [SerializeField]
    private float maxDistance;

    void Start()
    {
        myAstronaut = astronautSO.astronautItems[characterIndex];
        
        if (myAstronaut != null)
        {
            health = myAstronaut.health;
            Debug.Log("Astronaut Start: " + myAstronaut.moveSpeed + ".");
            moveSpeed = myAstronaut.moveSpeed;
        }
    }


    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, myAstronaut.attackRange, layermask);

        if (hit.collider != null)
        {
            Stop();
            Attack();
        }
        else if (transform.position.x >= maxDistance) {
            Stop();
        }
        else
        {
            Move();
        }

        /* moveSpeed = 0: Stop, !0: Move */
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    // public void AllocateItem(AstronautItem item) {
        // myAstronaut = item;
    // }

    private void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            StartCoroutine(CreateBullet());
        }
    }

    private IEnumerator CreateBullet()
    {
        myAstronaut.BulletPrefab.GetComponent<Bullet>().SetBullet(myAstronaut);
        Instantiate(myAstronaut.BulletPrefab, transform.position, transform.rotation);
        
        // Wait for a short duration before allowing another attack
        yield return new WaitForSeconds(myAstronaut.attackSpeed);
        isAttacking = false;
    }

    private void Move()
    {
        moveSpeed = myAstronaut.moveSpeed;
    }

    private void Stop()
    {
        moveSpeed = 0;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
}
