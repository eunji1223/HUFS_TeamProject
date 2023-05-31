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
    private GameObject obstacleRay;
    private LayerMask layermask;

    private void Start() {
        health = myAstronaut.health;
    }

    private void Update() {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, myAstronaut.attackRange, layermask);

        /* moveSpeed = 0: Stop, !0: Move */
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (hit.collider != null) {
            Stop();
            Attack();
        }
        else {
            Move();
        }
    }

    public void AllocateItem(AstronautItem item) {
        myAstronaut = item;
    }

    private void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            StartCoroutine("CreateBullet", myAstronaut);
        }
    }

    private void CreateBullet() {
        myAstronaut.BulletPrefab.GetComponent<Bullet>().SetBullet(myAstronaut);
        Instantiate(myAstronaut.BulletPrefab, transform.position, transform.rotation);
    }

    private void Move() {
        moveSpeed = myAstronaut.moveSpeed;
    }

    private void Stop() {
        moveSpeed = 0;
    }

    private void Die() {
        Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) {
            Die();
        }

    }
}
