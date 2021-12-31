using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public float bulletDamage = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<HealthLogic>().CurrentHealth -= bulletDamage;
            DestroyBullet();
        }

        if (other.CompareTag("Destroyable"))
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
