using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    public float speed;
    public bool target;
    public Color newColor;
    public Transform startingPoint;
    private GameObject player;
    private ParticleSystem particles;
    bool burning = false;
    public GameObject fire;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        particles = transform.parent.GetComponentInChildren<ParticleSystem>();
    }

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
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, (speed+4) * Time.deltaTime);

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
    private IEnumerator EnemyRecoil()
    {
        Debug.Log("did we do it");
        target = false;
        yield return new WaitForSeconds(1);
        target = true;
    }
    public override void Hit(Transform player)
    {
        Debug.Log("HERE");
        StartCoroutine(EnemyRecoil());
    }
}
