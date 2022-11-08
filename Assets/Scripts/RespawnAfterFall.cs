using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAfterFall : MonoBehaviour
{
    private CharacterController2D controller;
    public Vector3 lastGroundedPos;

    private void Start()
    {
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
}
