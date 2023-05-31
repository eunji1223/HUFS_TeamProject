using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    private float deadZone = 10f;
    private float speed;

    void Update()
    {
        this.gameObject.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        if (this.gameObject.transform.position.x > deadZone)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // enemy 체력 줄어들게
            Destroy(gameObject);
        }
    }
    public void SetBullet(float gunSpeed)
    {
        speed = gunSpeed;
    }

}
