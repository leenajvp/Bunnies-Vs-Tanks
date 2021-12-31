using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float Spawntime;
    public float StartSpawn;

    public bool Spawning;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", StartSpawn, Spawntime);
    }

   public void SpawnEnemy()
    {
        if (Spawning == true)
        {
            GameObject.Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
        
    }
}

