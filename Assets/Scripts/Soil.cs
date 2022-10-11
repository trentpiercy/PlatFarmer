using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    // Has a seed been planted
    public bool hasSeed = false;

    // Is the soil watered
    public bool hasWater = false;

    // Only allow tree to be grown once
    public bool treeGrown = false;

    public void PlantSeed()
    {
        hasSeed = true;
        Debug.Log("Planted Seed.");

        TryGrowTree();
    }
    
    public void WaterSoil()
    {
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

            Debug.Log("Soil has seed and water! Planting tree");

            // TODO spawn a tree object

            Debug.Log("Tree is grown.");
        }
    }


    void Update()
    {
    }
}