using System.Collections;
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
    public AudioSource seedFall;

    public void DropToPlant()
    {
        StartCoroutine(DropRoutine());
        seedFall.Play();
    }

    private IEnumerator DropRoutine()
    {
        for (int i = 0; i < 100; i++)
        {
            if (CheckPlanted())
                break;

            yield return new WaitForFixedUpdate();
        }
    }

    private bool CheckPlanted()
    {
        if (GetComponent<Collider2D>().IsTouchingLayers(soilLayer))
        {
            Debug.Log("Seed hit soil");
            Collider2D[] hitSoils = Physics2D.OverlapCircleAll(plantLocation.position, plantRange, soilLayer);
            if (hitSoils.Length > 0)
            {
                SoilTilemap soil = hitSoils[0].gameObject.GetComponent<SoilTilemap>();
                if (soil.PlantSeed(transform.position))
                {
                    Destroy(gameObject);

                    return true;
                }
            }
        }

        return false;
    }
}