using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Astronaut : MonoBehaviour
{
    private Item myAstronaut;
    private int health;

    private void Update()
    {
        StopRange();
    }

    private void OnEnable()
    {
        health = myAstronaut.health;
    }

    public void AllocateItem(Item item)
    {
        myAstronaut = item;
    }

    private void Attack()
    {
        switch (myAstronaut.hitType)
        {
            case 0:
            case 1:
                StartCoroutine("CreateBullet", myAstronaut.regenTime);
                break;
            case 2:

            case 3:
            case 4:
                break;
            case 5:

                break;
            case 6:

                break;
            default:

                break;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            // 죽는 애니메이션 실행
            Destroy(this.gameObject);
        }

    }

    protected void StopRange()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, transform.right, 8.0f);
        Debug.DrawRay(transform.position, transform.right * myAstronaut.maxDistance, Color.blue, 0.3f);
        Debug.Log(hit);
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            float distance = hit.collider.transform.position.x - this.transform.position.x;
            if (distance < myAstronaut.maxDistance)
            {
                this.transform.position = Vector2.zero;
                Attack();
                //StartCoroutine("CreateBullet", myAstronaut.regenTime);    
            }
        }
    }

    private void CreateBullet()
    {
        myAstronaut.bulletPre.GetComponent<bullet>().SetBullet(myAstronaut.gunSpeed);
        Instantiate(myAstronaut.bulletPre, this.transform.position, this.transform.rotation);
    }
}
