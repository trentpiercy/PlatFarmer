using UnityEngine;
using UnityEngine.Events;

public class Seed : MonoBehaviour
{
    private bool hitSoil = false; // if the seed has hit soil
    public LayerMask soilLayer; // all soils
    public Transform plantLocation;  // Point to check plant range from
    public float plantRange;  // How far can the player reach to plant a seed

    void Update()
    {
        
        if (gameObject.GetComponent<Collider2D>().IsTouchingLayers(soilLayer))
        {
            Debug.Log("Hit Soil!");
            // Soil soil = hitSoils[i].gameObject.GetComponent<Soil>();
            // soil.PlantSeed();
            Destroy(gameObject);            
        }

    }
    
}