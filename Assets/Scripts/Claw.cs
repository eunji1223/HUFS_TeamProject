using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour
{
    public float speed;
    public float damage;

    void Update() {
        Move();
    }

    private void Move() {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void SetSpeed(float newSpeed) {
        speed = newSpeed;
    }

    public void SetDamage(float newDamage) {
        damage = newDamage;
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
