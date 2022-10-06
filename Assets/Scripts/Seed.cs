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
        
        // P = Plant Seed
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            Collider2D[] hitSoils = Physics2D.OverlapCircleAll(plantLocation.position, plantRange, soilLayer);
            for (int i = 0; i < hitSoils.Length; i++)
            {
                Soil soil = hitSoils[i].gameObject.GetComponent<Soil>(); 
                soil.PlantSeed();
                Destroy(gameObject);
            }
        }

    }
    
}