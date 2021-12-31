using UnityEngine;

public class HealthBox : MonoBehaviour
{
    public float HealthUp;
    public GameObject Collector;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Collector)
        {
            Collector.gameObject.GetComponent<HealthLogic>().CurrentHealth += HealthUp;
            Destroy(gameObject);
        }
    }
}
