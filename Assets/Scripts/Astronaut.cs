using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour
{
    public float health = 10.0f;
    public float moveSpeed = 2.0f;
    public float attackRange = 10.0f;
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public GameObject missile;

    private bool isAttacking = false;

    private void Update()
    {
        // Move the astronaut to the right
        if (!isAttacking) {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        // Check for enemies in the attack range
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(new Vector3(attackPoint.position.x + (attackRange/2), attackPoint.position.y, 0), new Vector2(attackRange, 2), 0f, enemyLayer);

        // If there are enemies in the attack range and not already attacking, start attacking
        if (hitEnemies.Length > 0 && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;

        GameObject missile = Instantiate(missile, attackPoint.position, Quaternion.identity);
        Missile missileComponent = missile.GetComponent<Missile>();
        if (missileComponent != null)
        {
            missileComponent.SetSpeed(5.0f); // Set the speed of the missile
            missileComponent.SetDamage(10.0f); // Set the damage of the missile
        }

        yield return new WaitForSeconds(1.0f); // Wait for the attack animation or action to complete

        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(new Vector3(attackPoint.position.x+(attackRange/2), attackPoint.position.y, 0), new Vector3(attackRange, 2.0f, 0f));
        }
    }
}