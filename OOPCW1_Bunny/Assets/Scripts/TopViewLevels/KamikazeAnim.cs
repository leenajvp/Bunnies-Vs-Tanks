using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeAnim : MonoBehaviour
{
    public GameObject player;
    private SpriteRenderer spriteRenderer;
    public Sprite explosion;
    public float damage;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthLogic>().CurrentHealth -= damage;
            StartCoroutine(Kamikazehit());
        }
    }

    public IEnumerator Kamikazehit()
    {
        spriteRenderer.sprite = explosion;
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
