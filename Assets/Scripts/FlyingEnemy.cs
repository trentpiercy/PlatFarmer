using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed;
    public bool target;
   
    public Transform startingPoint;
    private GameObject player;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Attacked()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if (target == true)
        {
            Chase();
            Flip();
        }
        else
        {
            ReturnToSpawnPoint();
        }
        
    }
    private void ReturnToSpawnPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);

    }
    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
