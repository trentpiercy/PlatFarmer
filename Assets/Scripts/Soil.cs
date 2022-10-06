using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{

    // if the soil has a seed planted
    private bool hasSeed = false; // fertile soil
    
    // if the soil is watered
    private bool hasWater = false; // watered soil

    private bool hasTree = false;
    private bool chopTree = false;
    // TODO: list of trees

    void PlantSeed()
    {
        hasSeed = true;
        Debug.Log("Planted Seed.");
    }
    
    void WaterSoil()
    {
        hasWater = true;
        Debug.Log("Watered Soil.");
    }
        
    void Update()
    {
        
        if (hasSeed && hasWater) // if you enter the collider of the object
        {
            Debug.Log("Soil has seed and water! Planting tree");
            // TODO: grow tree
            Debug.Log("Tree is grown.");
            
        } else if (hasSeed)
        {
            Debug.Log("Soil has seed!");
            // TODO: change display to fertile soil
            Debug.Log("Soil has turned into fertile soil.");
        } else if (hasWater)
        {
            Debug.Log("Soil has water!");
            // TODO: change display to watered soil
            Debug.Log("Soil has turned into watered soil.");
        }
        else if (hasTree && chopTree)
        {
            // TODO: chop tree
            // TOOD: remove from list of trees
        }
        
        

    }
    
}