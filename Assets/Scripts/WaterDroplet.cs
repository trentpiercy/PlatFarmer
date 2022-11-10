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
    public void Drop()
    {
        StartCoroutine(DropRoutine());
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
            for (int i = 0; i < hitSoils.Length; i++)
            {
                Soil soil = hitSoils[i].gameObject.GetComponent<Soil>();
                soil.WaterSoil();
                Destroy(gameObject);

                return true;
            }
        }

        return false;
    }
}