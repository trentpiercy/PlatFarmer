using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : Enemy
{
    public Transform leftmost;
    public Transform rightmost;
    public Color burnColor;
    public float moveSpeed = 2f;

    int direction = -1;
    Rigidbody2D rb;

    bool burning = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetVelocity();
    }

    // Called when hit by player
    public override void Attacked()
    {
        Destroy(gameObject);
    }

    public override void Burn()
    {
       if (!burning)
        {
            burning = true;
            StartCoroutine(BurnRoutine());
        }
    }

    private IEnumerator BurnRoutine()
    {
        GetComponent<SpriteRenderer>().color = burnColor;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (transform.position.x < leftmost.position.x)
        {
            Flip();
        } 
        else if (transform.position.x > rightmost.position.x)
        {
            Flip();
        }
        else if (rb.velocity.magnitude < 0.1)
        {
            Flip();
        }
    }

    // Change goomba direction
    private void Flip()
    {
        direction = -direction;
        FlipModel();
        SetVelocity();
    }

    // Visually flip the model
    private void FlipModel()
    {
        transform.localScale = new Vector3(-transform.localScale.x, 
            transform.localScale.y, transform.localScale.z);
    }

    private void SetVelocity()
    {
        rb.velocity = new Vector2(direction * moveSpeed, 0);
    }

    public override void Hit(Transform player)
    {
        // If moving right and hit from right, flip
        if (direction == 1 && player.position.x > transform.position.x)
        {
            Flip();
        }
        // If moving left and hit from left, flip
        else if (direction == -1 && player.position.x < transform.position.x)
        {
            Flip();
        }
    }
}
