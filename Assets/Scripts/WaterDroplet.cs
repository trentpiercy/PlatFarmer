using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WaterDroplet : MonoBehaviour
{
    // All soils
    public LayerMask soilLayer;

    // Ground layer
    public LayerMask groundLayer;

    // Point to check watering range from
    public Transform waterLocation;

    // How far can the player reach to water soil
    public float waterRange;
    public AudioSource waterDrop;

    public void DropToPlant()
    {
        StartCoroutine(DropRoutine());
        waterDrop.Play();
    }

    private IEnumerator DropRoutine()
    {
        for (int i = 0; i < 100; i++)
        {
            if (CheckWatered())
                break;

            yield return new WaitForFixedUpdate();
        }
    }

    private bool CheckWatered()
    {
        if (GetComponent<Collider2D>().IsTouchingLayers(soilLayer))
        {
            Debug.Log("Water hit soil");
            Collider2D[] hitSoils = Physics2D.OverlapCircleAll(waterLocation.position, waterRange, soilLayer);
            if (hitSoils.Length > 0)
            {
                SoilTilemap soil = hitSoils[0].gameObject.GetComponent<SoilTilemap>();
                if (soil.WaterSoil(transform.position))
                {
                    Destroy(gameObject);
                    return true;
                }

                return true;
            }
        }

        return false;
    }
}