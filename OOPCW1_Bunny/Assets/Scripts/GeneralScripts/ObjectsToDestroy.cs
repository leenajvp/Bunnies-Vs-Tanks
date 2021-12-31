using UnityEngine;

public class ObjectsToDestroy : MonoBehaviour
{
    void Update()
    {
        if (gameObject.GetComponent<HealthLogic>().CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
