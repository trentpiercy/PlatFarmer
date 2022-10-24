using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseZone : MonoBehaviour
{

    public FlyingEnemy[] enemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (FlyingEnemy enemy in enemies)
            {
                enemy.target = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (FlyingEnemy enemy in enemies)
            {
                enemy.target = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
