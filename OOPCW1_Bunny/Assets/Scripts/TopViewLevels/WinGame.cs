using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameObject WinnerState;
    public GameObject Player;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            YayYouWon();
        }

    }

    public void YayYouWon()
    {
        Debug.Log("yay you won");
        Cursor.visible = true;
        WinnerState.SetActive(true);
        Time.timeScale = 0f;
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<SJPlayerMovement>().enabled = false;
    }
}
