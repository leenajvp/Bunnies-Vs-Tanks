using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multilock : MonoBehaviour
{
    public Keys KeyNeeded;
    public GameObject[] TurnOffObjects;
    public GameObject[] TurnOnObjects;
    public GameObject Player;

    private void Awake()
    {
        foreach (GameObject go in TurnOnObjects)
        {
            go.gameObject.GetComponent<Spawner>().Spawning = false;
        }
    }
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

                    foreach (GameObject go in TurnOnObjects)
                    {
                        go.gameObject.GetComponent<Spawner>().Spawning = true;   
                    }

                    foreach (GameObject go in TurnOffObjects)
                    {
                        go.gameObject.GetComponent<Spawner>().Spawning = false;
                    }                 
                }
            }
        }
    }
    //TurnOnObjects[TurnOnObjects.Length].SetActive(true);
    /*                    TurnOnItem1.SetActive(true);
                        TurnOnItem2.SetActive(true);
                        TurnOnItem3.SetActive(true);
                        Destroy(TurnOffItem1);
                        Destroy(TurnOffItem2);*/

    //Destroy(go);
    //go.gameObject.GetComponent<Spawner>().enabled = false;

    //SetActive(true);

    /*    private void Start()
    {

    }*/

    // TurnOn.GetComponent<Spawner>().Spawning = true;

    /*        TurnOnItem1.SetActive(false);
            TurnOnItem2.SetActive(false);
            TurnOnItem3.SetActive(false);*/
    /*      foreach (GameObject go in TurnOnObjects)
          {
              //go.SetActive(false);
              go.gameObject.GetComponent<Spawner>().enabled = false;
          }*/
    //TurnOnObjects[gameObject].SetActive(false);
    //Destroy(go);
    //go.gameObject.GetComponent<Spawner>().enabled = false;
    //public Spawner TurnOn;
    /*    public GameObject TurnOnItem1;
        public GameObject TurnOnItem2;
        public GameObject TurnOnItem3;
        public GameObject TurnOffItem1;
        public GameObject TurnOffItem2;*/

    // public GameObject Enemy;
}
