using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JLEnemyLogics : MonoBehaviour
{
    public GameObject tank;

    public float speed;

    public SpriteRenderer spriteRenderer;
    public Sprite explosion;

    public Vector3 pointA;
    public Vector3 pointB;

    void Start()
    {
        MoveAtoB();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public virtual void Update()
    {
        if (gameObject.GetComponent<HealthLogic>().CurrentHealth <= 0)
        {
            EnemyDead();
        }
    }

    public void EnemyDead()
    {
        StartCoroutine(explosionanim());
    }

    public IEnumerator explosionanim()
    {
        spriteRenderer.sprite = explosion;
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }


    public void MoveAtoB()
    {
        StartCoroutine(MoveLogic(tank.transform, pointA, pointB));
    }

    IEnumerator MoveLogic(Transform targetObject, Vector3 PosA, Vector3 PosB)
    {
        while (true)
        {
            yield return moveToX(targetObject, PosB, speed);
            yield return moveToX(targetObject, PosA, speed);
        }
    }

    IEnumerator moveToX(Transform targetObject, Vector3 toPosition, float speed)
    {
        float startTime;
        float Length;
        startTime = Time.time;
        Vector3 startPos = targetObject.position;
        Length = Vector3.Distance(startPos, toPosition);

        if (startPos == toPosition)
            yield break;

        while (true)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / Length;

            targetObject.position = Vector3.Lerp(startPos, toPosition, fracJourney);

            if (fracJourney >= 1)
                yield break;

            yield return null;
        }
    }
}

