using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlowCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask playerLayer;
    public GameObject logo;
    public float zoomSpeed;
    public float zoomAmount;
    private float logoX = 0f;
    private float logoY = 0f;

    private Camera cam;
    private CameraMovement move;

    private void Start()
    {
        cam = Camera.main;
        move = cam.GetComponent<CameraMovement>();

    }

    void Update()
    {
        logo.transform.localScale = new Vector3(logoX, logoY, 0);
        if (GetComponent<Collider2D>().IsTouchingLayers(playerLayer))
        {
            move.cameraSpeed = 0;
            cam.orthographicSize -= zoomSpeed * Time.deltaTime;
            logoX += 20 * Time.deltaTime;
            logoY += 20 * Time.deltaTime;

            if (cam.orthographicSize < zoomAmount)
            {
                cam.orthographicSize = zoomAmount; // Max size
                
            }
            if (logoX > 70)
            {
                logoX = 70f; // Max size
                logoY = 70f;
            }
        }
        else
        {
            cam.orthographicSize += 6 * Time.deltaTime;
            if (cam.orthographicSize > 8)
            {
                cam.orthographicSize = 8; // Max size
            }
        }
        
    }
}
