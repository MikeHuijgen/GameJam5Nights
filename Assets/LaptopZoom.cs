using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopZoom : MonoBehaviour
{
    int zoom = 30;
    int normal = 60;
    float smooth = 5;

    private bool isZoomed = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isZoomed = !isZoomed;
        }

        if (isZoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
        }

        else
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }
    }
}
