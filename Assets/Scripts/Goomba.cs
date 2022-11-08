using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : Enemy
{
    public Transform leftmost;
    public Transform rightmost;
    public Color newColor;
    public float moveSpeed = 2f;

    private int direction = -1;

    // Called when hit by player
    public override void Attacked()
    {
        Destroy(gameObject);
    }

    public override IEnumerator Burn()
    {
        GetComponent<SpriteRenderer>().color = newColor;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x < leftmost.position.x)
        {
            direction = 1;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        } 
        else if (transform.position.x > rightmost.position.x)
        {
            direction = -1;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
