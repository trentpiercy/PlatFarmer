using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private CharacterController2D controller;
    public Vector3 lastGroundedPos;
    public int hp;
    public int totalHealth = 3;

    private void Start()
    {
        hp = 3;
        controller = GetComponent<CharacterController2D>();
        StartCoroutine(SpawnPoint());
    }

    private IEnumerator SpawnPoint() 
    {
        while (true)
        {
            if (controller.m_Grounded)
            {
                lastGroundedPos = transform.position;
                yield return new WaitForSeconds(2f);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Respawn()
    {
        transform.position = lastGroundedPos;
    }
    private void Update()
    {
        //// Restart
        if (hp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
