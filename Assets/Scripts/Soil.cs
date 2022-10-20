using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Soil : MonoBehaviour
{
    public GameObject tree;
    // Has a seed been planted
    public bool hasSeed = false;

    // Is the soil watered
    public bool hasWater = false;

    // Only allow tree to be grown once
    public bool treeGrown = false;

    public Color green = new(170, 255, 0);
    public Color blue = Color.blue;

    public void PlantSeed()
    {
        GetComponent<SpriteRenderer>().color = green;
        hasSeed = true;
        Debug.Log("Planted Seed.");

        TryGrowTree();
    }
    
    public void WaterSoil()
    {
        GetComponent<SpriteRenderer>().color = blue;
        hasWater = true;
        Debug.Log("Watered Soil.");

        TryGrowTree();
    }

    private void TryGrowTree()
    {
        // Quit if already grown
        if (treeGrown) return;

        // Grown if both seed and water
        if (hasSeed && hasWater)
        {
            treeGrown = true;
            Instantiate(tree, new Vector3(transform.position.x, transform.position.y + 1.6f, transform.position.z), Quaternion.identity);
            Debug.Log("Soil has seed and water! Planting tree");

            Debug.Log("Tree is grown.");
        }
    }


    private void Start()
    {
        if (hasSeed) PlantSeed();
        if (hasWater) WaterSoil();
    }
}