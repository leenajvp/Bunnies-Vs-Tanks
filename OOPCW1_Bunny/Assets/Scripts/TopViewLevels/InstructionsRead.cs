using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsRead : MonoBehaviour
{
    public GameObject Instructions;
    public GameObject Player;
    public GameObject Spawner;

    void Awake()
    {
        Instructions.SetActive(true);
        Player.GetComponent<PlayerMovement>().enabled = false;
        Spawner.SetActive(false);
    }

    void Update()
    {
        
    }

    public void InstructionsReadbutton()
    {
        Instructions.SetActive(false);
        Player.GetComponent<PlayerMovement>().enabled = true;
        Spawner.SetActive(true);
    }
}
