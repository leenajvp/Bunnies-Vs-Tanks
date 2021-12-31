using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossEnum : EnemyLogics
{
    public enum EnemyState
    {
        None,
        KillPlayer,
        GetHealth
    }

    public EnemyState CurrentState;
    public float minHealth;
    public Transform EnemyHealthBox;

    public override void Update()
    {
        CheckHealth();

        switch (CurrentState)
        {
            case EnemyState.None:

                DoNothing();
                break;

            case EnemyState.KillPlayer:

                base.GetThePlayer();
                break;

            case EnemyState.GetHealth:
                FindHealth();
                break;

            default:
                break;
        }
    }

    public void DoNothing()
    {
        if (Health.CurrentHealth > minHealth && gameObject.GetComponent<Spawner>().Spawning == true)
        {
            CurrentState = EnemyState.KillPlayer;
        }
    }

    public void CheckHealth()
    {
        if (CurrentState != EnemyState.None)
        {
            if (Health.CurrentHealth < minHealth && CurrentState == EnemyState.KillPlayer && gameObject.GetComponent<Spawner>().Spawning == true)
            {
                CurrentState = EnemyState.GetHealth;
            }
            else if (Health.CurrentHealth > minHealth && gameObject.GetComponent<Spawner>().Spawning == true)
            {
                CurrentState = EnemyState.KillPlayer;
            }
        }
    }

    public void FindHealth()
    {
        transform.position = Vector2.MoveTowards(transform.position, EnemyHealthBox.position, enemySpeed * Time.deltaTime);
    }
}

