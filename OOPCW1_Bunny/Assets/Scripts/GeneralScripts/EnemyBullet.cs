using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public float bulletDamage = 10f;

    private Vector2 target;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x==target.x && transform.position.y == target.y)
        {
            DestroyBullet();
        }
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
