using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    private Vector3 target;
    public GameObject pointer;
    public GameObject gun;
    private GameObject bullet;
    public GameObject shootPoint;
    public GameObject player;

    public List<PlayerBullet> Bullets;
    public BulletSelection bulletSelected;


    void Start()
    {
        Cursor.visible = false;
        bullet = Bullets[bulletSelected.currentBullet].gameObject;
    }

    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        pointer.transform.position = new Vector3(target.x, target.y);
        Vector3 difference = target - gun.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            FireBullet(direction, rotationZ);
        }
    }

    void FireBullet(Vector2 direction, float rotationZ)
    {
        try
        {
            bullet = Bullets[bulletSelected.currentBullet].gameObject;
            GameObject b = Instantiate(bullet) as GameObject;
            b.transform.position = shootPoint.transform.position;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            b.GetComponent<Rigidbody2D>().velocity = direction * Bullets[bulletSelected.currentBullet].gameObject.GetComponent<PlayerBullet>().speed;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}
