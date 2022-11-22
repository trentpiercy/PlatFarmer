using UnityEngine;

public class Ladder : MonoBehaviour
{
    private float vertical;
    private float speed = 6f;
    private bool isLadder;
    private bool isClimbing;
    public AudioSource footsteps;
    private bool soundPlaying = false;

    private Rigidbody2D player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (isLadder)
        {
            if (Mathf.Abs(vertical) > 0f)
            {
                isClimbing = true;
                if (!soundPlaying)
                {
                    footsteps.Play();
                    soundPlaying = true;
                }
            }
            else
                {
                //isClimbing = false;
                if (soundPlaying)
                {
                    footsteps.Stop();
                    soundPlaying = false;
                }
                }
        }
        else
        {
            if (soundPlaying)
            {
                footsteps.Stop();
                soundPlaying = false;
            }
        }

    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            player.gravityScale = 0f;
            player.velocity = new Vector2(player.velocity.x, vertical * speed);
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
            player.gravityScale = 3f;
        }
    }
}