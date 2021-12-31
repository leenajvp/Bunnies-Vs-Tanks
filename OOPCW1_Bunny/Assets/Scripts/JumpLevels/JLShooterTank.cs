using System.Collections;
using UnityEngine;

public class JLShooterTank : JLEnemyLogics
{
    private float bulletTimer;
    public float shootingStart;

    public GameObject bullet;

    void Start()
    {
        base.MoveAtoB();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void Update()
    {

        if (bulletTimer <= 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            bulletTimer = shootingStart;
        }

        else
        {
            bulletTimer -= Time.deltaTime;
        }

        if (gameObject.GetComponent<HealthLogic>().CurrentHealth <= 0)
        {
            base.EnemyDead();
        }
    }
}
