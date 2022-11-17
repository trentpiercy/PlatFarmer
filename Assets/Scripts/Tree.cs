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
    //public AudioSource treeFall;
    private Transform player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    public void ChopTree()
    {
        Debug.Log("HERE in ChopTree "+ standing);
        if (standing)
        {
            //treeFall.Play();
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
            Vector3 vec = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(log, vec, Quaternion.Euler(0, 0, 0));
            Instantiate(log, vec, Quaternion.Euler(0, 0, 0));
            Instantiate(seed, vec, Quaternion.Euler(0, 0, 0));

            Destroy(gameObject);
        }

    }
    public IEnumerator Burn()
    {
        GetComponent<SpriteRenderer>().color = newColor;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
