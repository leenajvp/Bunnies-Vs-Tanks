using UnityEngine;

public class RandomPositions : MonoBehaviour
{
    public Vector2[] positions;

    void Start()
    {
        int randomNumber = Random.Range(0, positions.Length);
        transform.position = positions[randomNumber];
    }
}
