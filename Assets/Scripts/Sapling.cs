using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapling : MonoBehaviour
{
    public GameObject seed;

    public void Chop()
    {
        Vector3 vec = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(seed, vec, Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }
}