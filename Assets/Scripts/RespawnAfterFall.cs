using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAfterFall : MonoBehaviour
{
    public CharacterController2D controller;
    public Vector3 lastGroundedPos;
    public static bool hasFallen;
    private bool isRunning = true;

    // Update is called once per frame
    void Update()

    {
        if (isRunning)
        {
            StartCoroutine(SpawnPoint());
        }
    }
    private IEnumerator SpawnPoint() {

        Debug.Log(controller.m_Grounded);
        if (controller.m_Grounded)
        {
            isRunning = false;
            lastGroundedPos = transform.position;
            yield return new WaitForSeconds(2.0f);
            isRunning = true;
            yield return new WaitForSeconds(2.0f);
        }
        else if (hasFallen == true)
        {
            transform.position = lastGroundedPos;
            hasFallen = false;
        }
    }
}
