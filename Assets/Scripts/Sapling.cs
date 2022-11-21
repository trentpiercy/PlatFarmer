using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapling : MonoBehaviour
{
    // Seed prefab
    public GameObject seed;

    public void Chop()
    {
        Instantiate(seed, transform.position, new Quaternion());

        GameObject.FindGameObjectWithTag("Soil")
            .GetComponent<SoilTilemap>().RemoveSeed(transform.position);

        Destroy(gameObject);
    }
}