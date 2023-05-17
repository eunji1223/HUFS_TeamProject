using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroAttack : MonoBehaviour
{
    public float speed;
    public float damage;

    void Update() {
        Move();
    }

    private void Move() {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void SetSpeed(float newSpeed) {
        speed = newSpeed;
    }

    public void SetDamage(float newDamage) {
        damage = newDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
