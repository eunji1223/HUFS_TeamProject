using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private BulletItem myBullet;

    void Update()
    {
        if (myBullet == null) {
            Debug.LogWarning("Bullet item not allocated.");
            return;
        }

        transform.Translate(Vector3.right * myBullet.attackSpeed * Time.deltaTime);
        
        if (transform.position.x >= myBullet.attackRange)
        {
            Destroy(gameObject);
        }
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

class BulletItem {
    public int attackRange;
    public int attackSpeed;
    public int damage;
    public bool isPenetrate;
    public bool isDot;
    public int dotDamage;
    public int dotTime;
}