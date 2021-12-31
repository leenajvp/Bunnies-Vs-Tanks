using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    HealthLogic health;


    private void Start()
    {
        health = GetComponentInParent<HealthLogic>();
    }
    void Update()
    {
        if (health.CurrentHealth >= 50)
        {
            GetComponent<SpriteRenderer>().material.color = Color.green;
        }

        if (health.CurrentHealth <= 50)
        {
            GetComponent<SpriteRenderer>().material.color = Color.yellow;
        }

        if (health.CurrentHealth <= 30)
        {
            GetComponent<SpriteRenderer>().material.color = Color.red;
        }
    }
}
