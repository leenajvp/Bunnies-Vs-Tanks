using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject mine;
    public GameObject mineBox;
    public GameObject itemDrop;

    public float HorizontalMoveSpeed;
    public float VerticalMoveSpeed;

    public bool mineCollected = false;

    private Animator animState;

    private void Start()
    {
        animState = GetComponent<Animator>();
    }

    void Update()
    {
        if (mineCollected == true)
        {
            DropMine();
        }

        if (Input.GetKey(KeyCode.A))
        {
            animState.SetInteger("AnimState", 2);
            transform.position += Vector3.left * HorizontalMoveSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            animState.SetInteger("AnimState", 1);
            transform.position += Vector3.right * HorizontalMoveSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            animState.SetInteger("AnimState", 1);
            transform.position += Vector3.up * VerticalMoveSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            animState.SetInteger("AnimState", 1);
            transform.position += Vector3.down * VerticalMoveSpeed;
        }

        if (!Input.anyKey)
        {
            animState.SetInteger("AnimState", 0);
        }

        if (gameObject.GetComponent<HealthLogic>().CurrentHealth <= 0)
        {
            GameOverScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == mineBox)
        {
            DropMine();
            mineCollected = true;
            Destroy(mineBox);
        }
    }

    public void GameOverScene()
    {
        animState.SetInteger("AnimState", 3);
        GameOver.SetActive(true);
        HorizontalMoveSpeed = 0;
        VerticalMoveSpeed = 0;
        Cursor.visible = true;
    }

    public void DropMine()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject.Instantiate(mine, itemDrop.transform.position, Quaternion.identity);
        }
    }
}
