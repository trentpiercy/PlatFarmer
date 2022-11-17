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

    public override IEnumerator Burn()
    {
        GetComponent<SpriteRenderer>().color = burnColor;
        yield return new WaitForSeconds(2);
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
}
