using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Soil : MonoBehaviour
{
    public GameObject tree;

    public GameObject sapling;

    // Has a seed been planted
    public bool hasSeed = false;

    // Is the soil watered
    public bool hasWater = false;

    public Color blue = Color.blue;

    private SpriteRenderer sprite;
    public AudioSource planted;

    public bool PlantSeed()
    {
        Debug.Log("TRYING TO PLANT");
        if (hasSeed) return false;

        sapling.SetActive(true);
        hasSeed = true;
        Debug.Log("Planted Seed.");

        TryGrowTree();

        return true;
    }
    
    public bool WaterSoil()
    {
        if (hasWater) return false;

        sprite.enabled = true;
        sprite.color = blue;

        hasWater = true;
        Debug.Log("Watered Soil.");

        TryGrowTree();

        return true;
    }

    private void TryGrowTree()
    {
        //// Quit if already grown
        //if (treeGrown) return;

        // Grown if both seed and water
        if (hasSeed && hasWater)
        {
            sapling.SetActive(false);
            sprite.enabled = false;

            hasSeed = false;
            hasWater = false;

            Instantiate(tree, new Vector3(transform.position.x, 
                transform.position.y + 1.6f, transform.position.z), 
                Quaternion.identity);
            Debug.Log("Soil has seed and water! Planting tree");
            planted.Play();
        }
    }


    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        if (hasSeed)
        {
            sapling.SetActive(true);
        } else if (hasWater)
        {
            sprite.color = blue;
        }
    }
}