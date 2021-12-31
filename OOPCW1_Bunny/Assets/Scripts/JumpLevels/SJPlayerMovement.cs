using System.Collections;
using UnityEngine;

public class SJPlayerMovement : MonoBehaviour
{
    public float Speed;

    public bool GroundCheck = true;
    public bool MineCollected = false;

    public GameObject mineBox;
    public GameObject mine;
    public GameObject itemDrop;
    public GameObject GameOver;

    private Rigidbody2D rb;
    private Animator animState;

    void Start()
    {
        animState = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        StartCoroutine(GroundCheckRoutine());
        CalculateMovement();
        Animations();

        if (MineCollected == true)
        {
            DropMine();
        }

        if (gameObject.GetComponent<HealthLogic>().CurrentHealth <= 0)
        {
            GameOverScene();
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * Speed * Time.deltaTime);
    }

    IEnumerator GroundCheckRoutine()
    {
        if (Input.GetKeyDown(KeyCode.W) && GroundCheck == true)
        {
            animState.SetInteger("AnimState", 3);
            GroundCheck = false;
            float jumpVelocity = 5f;
            rb.velocity = Vector2.up * jumpVelocity;
            yield return new WaitForSeconds(1f);
            GroundCheck = true;
        }
    }

    private void Animations()
    {
        if (Input.GetKey(KeyCode.A))
        {
            animState.SetInteger("AnimState", 2);
        }

        if (Input.GetKey(KeyCode.D))
        {
            animState.SetInteger("AnimState", 1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            animState.SetInteger("AnimState", 3);
        }

        if (!Input.anyKey)
        {
            animState.SetInteger("AnimState", 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == mineBox)
        {
            DropMine();
            MineCollected = true;
            Destroy(mineBox);
        }
    }

    public void DropMine()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject.Instantiate(mine, itemDrop.transform.position, Quaternion.identity);
        }
    }

    public void GameOverScene()
    {
        animState.SetInteger("AnimState", 5);
        GameOver.SetActive(true);
        Speed = 0;
        Cursor.visible = true;
    }
}
