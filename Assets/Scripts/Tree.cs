using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject log;
    public GameObject seed;
    public Color newColor;
    public Transform hitLocation;
    public float forceX;
    public float forceY;
    public bool standing = true;
    public AudioSource treeFall;
    private Transform player;
    bool burning = false;

    private void Start()
    {
        standing = true;

        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    public void ChopTree()
    {
        Debug.Log("Standing: " + standing);
        if (standing)
        {
            treeFall.Play();
            rb.constraints = RigidbodyConstraints2D.None;

            if (transform.position.x > player.transform.position.x)
            {
                rb.AddForceAtPosition(new Vector2(forceX, forceY), hitLocation.position);
            }
            else
            {
                rb.AddForceAtPosition(new Vector2(-forceX, forceY), hitLocation.position);
            }

            standing = false;
        }
        else
        {
            //Instantiate(log, vec, Quaternion.Euler(0, 0, 0));
            Instantiate(log, transform.position, new Quaternion());
            Instantiate(seed, transform.position, new Quaternion());

            Destroy(gameObject);
        }

    }
    public void Burn()
    {
        if (!burning)
        {
            burning = true;
            StartCoroutine(BurnRoutine());
        }
    }

    private IEnumerator BurnRoutine()
    {
        GetComponent<SpriteRenderer>().color = newColor;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
