using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraGrow : MonoBehaviour
{
    public LayerMask playerLayer;

    public float zoomSpeed = 6;
    public float normalSize = 8;
    public float maxSize = 11;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (GetComponent<Collider2D>().IsTouchingLayers(playerLayer))
        {
            cam.orthographicSize += zoomSpeed * Time.deltaTime;
            if (cam.orthographicSize > maxSize)
            {
                cam.orthographicSize = maxSize; // Max size
            }
        }
        else
        {
            cam.orthographicSize -= zoomSpeed * Time.deltaTime;
            if (cam.orthographicSize < normalSize)
            {
                cam.orthographicSize = normalSize; // Max size
            }

        }
    }

}
