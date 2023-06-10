using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private AstronautSO astronautSO;
    private AstronautItem myBullet;
    [SerializeField]
    private int bulletIndex;

    private Rigidbody2D rb;

    void Start() {
        myBullet = astronautSO.astronautItems[bulletIndex];
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x >= myBullet.attackRange) {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.right * 5 * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Alien")) {
            Alien alien = collision.GetComponent<Alien>();

            // Get Damage on being hit
            alien.TakeDamage(myBullet.damage);

            // Dot Damage
            if (myBullet.isDot) {
                StartCoroutine(ApplyDotDamage(alien, myBullet.dotTime));
            }

            if (myBullet.isSlow) {
                alien.getSlow(myBullet.slowTime);
            }

            // Penetrate -> Not destroy on hit
            if (!myBullet.isPenetrate) {
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator ApplyDotDamage(Alien alien, int dotTime) {

        while (dotTime > 0) {
            alien.TakeDamage(myBullet.dotDamage);
            dotTime--;
            yield return new WaitForSeconds(1f);
        }
    }

    public void SetBullet(AstronautItem item) {

        myBullet.attackRange = item.attackRange;
        myBullet.attackSpeed = item.attackSpeed;
        myBullet.damage = item.damage;
        myBullet.isPenetrate = item.isPenetrate;
        myBullet.isDot = item.isDot;
        myBullet.dotDamage = item.dotDamage;
        myBullet.dotTime = item.dotTime;
    }
}

