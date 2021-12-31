using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmines : MonoBehaviour
{
    public float bulletDamage = 10f;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<HealthLogic>().CurrentHealth -= bulletDamage;
            DestroyBullet();
        }

        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthLogic>().CurrentHealth -= bulletDamage;
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
