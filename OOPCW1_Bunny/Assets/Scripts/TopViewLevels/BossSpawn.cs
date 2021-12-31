using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public GameObject objectDrop;

    void Start()
    {
        objectDrop.SetActive(false);   
    }

    void Update()
    {

        if (gameObject.GetComponent<HealthLogic>().CurrentHealth <= 0)
        {
            objectDrop.SetActive(true);
            Destroy(gameObject);
        }
    }
}
