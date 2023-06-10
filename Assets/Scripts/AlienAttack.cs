using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAttack : MonoBehaviour
{
    [SerializeField]
    private AlienSO alienSO;
    private AlienItem myAttack;
    [SerializeField]
    private int attackIndex;

    private Rigidbody2D rb;

    void Start() {
        myAttack = alienSO.alienItems[attackIndex];
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x >= myAttack.attackRange) {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.left * myAttack.attackSpeed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Astronaut")) {
            Astronaut astronaut = collision.GetComponent<Astronaut>();

            if (myAttack.isStun == true) {
                astronaut.Stun(myAttack.stunTime);
            }
            // Get Damage on being hit
            astronaut.TakeDamage(myAttack.damage);

            Destroy(gameObject);
        }
    }
}

