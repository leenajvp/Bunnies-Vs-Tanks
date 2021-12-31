using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JLEnemyBullet : MonoBehaviour
{
    Vector2 direction = new Vector2(-1f, 0f);
    public float speed;
    public float bulletDamage;
    Rigidbody2D rb;

    public void Start()
    {       
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        direction = new Vector2(-1f, 0f);
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthLogic>().CurrentHealth -= bulletDamage;
            DestroyBullet();
        }

        if (other.CompareTag("Object"))
        {
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
