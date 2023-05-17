using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAttack : MonoBehaviour
{
    public float speed;
    public int damage;
    public float attackRange;

    void Update() {
        Move();

        if (transform.position.x <= attackRange) {
            Destroy(gameObject);
        }
    }

    private void Move() {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void SetSpeed(float newSpeed) {
        speed = newSpeed;
    }

    public void SetDamage(int newDamage) {
        damage = newDamage;
    }

    public void SetRange(float newRange) {
        attackRange = newRange;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Astronaut")) {
            Astronaut astronaut = collision.GetComponent<Astronaut>();
            if (astronaut != null) {
                astronaut.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
