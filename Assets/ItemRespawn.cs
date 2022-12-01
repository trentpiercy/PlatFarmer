using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    Vector3 initialPos;

    void Start()
    {
        initialPos = transform.position;
    }

    void Update()
    {
        if (transform.position.y < -40 && transform.parent == null)
        {
            transform.position = initialPos;
        }
    }
}
