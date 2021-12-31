using UnityEngine;

public class GunNotCollected : MonoBehaviour
{
    public GameObject MappedGun;
    public GameObject CollectedGun;
    public GameObject player;
    public GameObject Camera;

    private void Awake()
    {
        Camera.GetComponent < Shooting>().enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            CollectedGun.SetActive(true);
            MappedGun.SetActive(false);
            Camera.GetComponent<Shooting>().enabled = true;
        }
    }
}
