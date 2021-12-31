using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Keys> keysCollected = new List<Keys>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Keys Key = collision.GetComponent<Keys>();

        if (Key != null)
        {
            keysCollected.Add(Key);

            Key.gameObject.SetActive(false);
        }
    }
}
