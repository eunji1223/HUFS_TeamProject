using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100.0f;
    public float moveSpeed = 2.0f;
    public float attackRange = 2.0f;
    public Transform attackPoint;
    public LayerMask astronautLayer;

    private bool isAttacking = false;

    private void Update()
    {
        // Move the enemy to the left
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Check for astronauts in the attack range
        Collider2D[] hitAstronauts = Physics2D.OverlapBoxAll(attackPoint.position, new Vector2(attackRange, attackRange), 0f, astronautLayer);

        // If there are astronauts in the attack range and not already attacking, start attacking
        if (hitAstronauts.Length > 0 && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;

        // Perform attack animation or actions here

        yield return new WaitForSeconds(1.0f); // Wait for the attack animation or action to complete

        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(attackPoint.position, new Vector3(attackRange, attackRange, 0f));
        }
    }
}