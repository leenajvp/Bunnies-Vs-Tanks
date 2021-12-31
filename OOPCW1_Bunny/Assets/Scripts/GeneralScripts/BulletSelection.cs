using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSelection : MonoBehaviour
{

    public int currentBullet;
    public Shooting playerShooting;
    public Text bulletInUse;

    public void Start()
    {
        currentBullet = 0;
    }

    public void Update()
    {
        BulletText();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            NextBullet();
            Debug.Log(currentBullet);
        }
    }

    public void NextBullet()
    {
        currentBullet++;

        if (currentBullet >= playerShooting.Bullets.Count)
        {
            currentBullet = 0;
        }
    }

    public void BulletText()
    {
        if (currentBullet == 0)
        {
            bulletInUse.text = "Fast Bullet Damage = 10";
        }

        if (currentBullet == 1)
        {
            bulletInUse.text = "Slow Bullet Damage = 30";
        }

        if (currentBullet == 2)
        {
            bulletInUse.text = "Rocket Bullet Damage = 40";
        }
    }
}
