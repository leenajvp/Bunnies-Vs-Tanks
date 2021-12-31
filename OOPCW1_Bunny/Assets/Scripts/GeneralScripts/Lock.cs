using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lock : MonoBehaviour
{
    public Keys KeyNeeded;

    public GameObject NextLevel;
    public GameObject Player;
   // public GameObject Enemy;

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerInventory inventory = other.gameObject.GetComponent<PlayerInventory>();

        if (inventory != null)
        {
            for (int i = 0; i < inventory.keysCollected.Count; i++)
            {
                if (inventory.keysCollected[i] == KeyNeeded)
                {
                    Destroy(gameObject);
                    nextLevel();
                }
            }
        }
    }

    public void nextLevel()
    {
        Cursor.visible = true;
        NextLevel.SetActive(true);
        Time.timeScale = 0f;
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<SJPlayerMovement>().enabled = false;      
    }
}
