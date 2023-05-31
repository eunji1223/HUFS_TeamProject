using Packages.Rider.Editor.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using UnityEngine;

using Debug = UnityEngine.Debug;

public class Astronaut : MonoBehaviour
{

    public static Astronaut instance { get; private set; }

    void Awake() => instance = this;

    private AstronautItem myAstronaut;
    private int health;

    [SerializeField]
    private GameObject obstacleRay;
    [SerializeField]
    private LayerMask layermask;

    private float TestMaxDistance = 5.0f;

    private void Update()
    {
        StopRange();
    }

    private void OnEnable()
    {
        //health = myAstronaut.health;
    }

    public void AllocateItem(AstronautItem item)
    {
        Debug.Log("실행");
        myAstronaut = item;
    }

    private void Attack()
    {
        switch (0)
        {
            case 0:
            case 1:
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
        RaycastHit2D hit = Physics2D.Raycast(obstacleRay.transform.position, Vector3.right * 10, 15.0f, layermask);
        if (hit.collider != null)
        {
            Debug.DrawRay(obstacleRay.transform.position, Vector3.right * 10, Color.red);
            float distance = hit.collider.transform.position.x - obstacleRay.transform.position.x;
            if (distance > TestMaxDistance)
            {
                this.transform.position += Vector3.right * Time.deltaTime;
            }
            else
            {
                //Attack();
                //StartCoroutine("CreateBullet", myAstronaut.regenTime);    
            }
        }
    }

    private void CreateBullet()
    {
        //myAstronaut.bulletPre.GetComponent<bullet>().SetBullet(myAstronaut.gunSpeed);
        //Instantiate(myAstronaut.bulletPre, this.transform.position, this.transform.rotation);
    }
}
