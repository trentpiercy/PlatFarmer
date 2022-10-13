using UnityEngine;

public class Ladder : MonoBehaviour
{
    private float vertical;
    private float speed = 3f;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D player;

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