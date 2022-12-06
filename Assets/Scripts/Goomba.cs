using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Goomba : Enemy
{
    public Transform leftmost;
    public Transform rightmost;
    public Color burnColor;
    public float moveSpeed = 2f;
    private ParticleSystem particles;
    public GameObject fire;

    int direction = -1;
    Rigidbody2D rb;

    bool burning = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetVelocity();
        Debug.Assert(fire != null);
        particles = transform.parent.GetComponentInChildren<ParticleSystem>();
    }

    // Called when hit by player
    public override void Attacked()
    {
        particles.transform.position = transform.position;
        particles.Play();
        Destroy(gameObject);
    }

    public override void Burn()
    {
       if (!burning)
        {
            burning = true;
            fire.SetActive(true);
            StartCoroutine(BurnRoutine());
        }
    }

    private IEnumerator BurnRoutine()
    {
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
