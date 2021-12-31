using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogics : MonoBehaviour
{
    public float enemySpeed;
    public float stoppingDistance;
    public float retreatDistance;
    public float shootingDistance;

    public float bulletTimer;
    public float shootingStart;

    public GameObject bullet;
    public Sprite explosion;
    public HealthLogic Health;

    public Transform player;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Health = GetComponent<HealthLogic>();
    }

    public virtual void Update()
    {
        GetThePlayer();
    }

    public void GetThePlayer()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);
        }

        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }

        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -enemySpeed * Time.deltaTime);
        }

        if (bulletTimer <= 0 && Vector2.Distance(transform.position, player.position) <= shootingDistance)
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
            EnemyDead();
        }
    }

    public void EnemyDead()
    {
        StartCoroutine(explosionanim());
    }

    IEnumerator explosionanim()
    {
        spriteRenderer.sprite = explosion;
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
