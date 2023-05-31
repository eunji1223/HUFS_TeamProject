using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAttack : MonoBehaviour
{
    private AttackItem attackItem;

    void Update()
    {
        if (attackItem == null) {
            Debug.LogWarning("Attack item not allocated.");
            return;
        }

        transform.Translate(Vector3.left * attackItem.attackSpeed * Time.deltaTime);
        
        if (transform.position.x >= attackItem.attackRange) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Astronaut")) {
            Astronaut astronaut = collision.GetComponent<Astronaut>();

            // Get Damage on being hit
            astronaut.TakeDamage(attackItem.damage);
        }
    }

    public void SetAttack(AlienItem item) {

        attackItem.attackRange = item.attackRange;
        attackItem.attackSpeed = item.attackSpeed;
        attackItem.damage = item.damage;
        attackItem.isStun = item.isStun;
        attackItem.stunTime = item.stunTime;
    }
}

class AttackItem {
    public int attackRange;
    public int attackSpeed;
    public int damage;
    public bool isStun;
    public int stunTime;
}
