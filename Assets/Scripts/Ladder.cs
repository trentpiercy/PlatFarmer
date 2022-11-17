using UnityEngine;

public class Ladder : MonoBehaviour
{
    private float vertical;
    private float speed = 6f;
    private bool isLadder;
    private bool isClimbing;

    private Rigidbody2D player;
    public AudioSource climbingSound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            player.gravityScale = 0f;
            player.velocity = new Vector2(player.velocity.x, vertical * speed);
        }
        else
        {
            player.gravityScale = 3f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}