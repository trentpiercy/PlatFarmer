using UnityEngine;
using UnityEngine.Events;

public class Seed : MonoBehaviour
{
    // All soils
    public LayerMask soilLayer;

    // Ground layer
    public LayerMask groundLayer;

    // Point to check plant range from
    public Transform plantLocation;

    // How far can the player reach to plant a seed
    public float plantRange;

    void Update()
    {
        if (GetComponent<Collider2D>().IsTouchingLayers(soilLayer))
        {
            Debug.Log("Hit soil");
            Collider2D[] hitSoils = Physics2D.OverlapCircleAll(plantLocation.position, plantRange, soilLayer);
            for (int i = 0; i < hitSoils.Length; i++)
            {
                Soil soil = hitSoils[i].gameObject.GetComponent<Soil>();
                if (soil.PlantSeed())
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}