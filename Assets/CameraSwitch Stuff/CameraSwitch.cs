using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;

    public List<Camera> camera = new List<Camera>();
    public int index = 0;

    void Start()
    {
        mainCamera.enabled = true;
        
        foreach(Camera c in camera)
        {
            c.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && mainCamera.enabled)
        {
            camera[index].enabled = true;
            mainCamera.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && !mainCamera.enabled)
        {
            if (index >= camera.Count - 1)
            {
                index = 0;
                camera[index].enabled = true;
                camera[camera.Count - 1].enabled = false;
            }
            else
            {
                index++;
                camera[index].enabled = true;
                camera[index - 1].enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !mainCamera.enabled)
        {
            if (index <= 0)
            {
                index = camera.Count - 1;
                camera[index].enabled = true;
                camera[0].enabled = false;
            }
            else
            {
                index--;
                camera[index].enabled = true;
                camera[index + 1].enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q) && !mainCamera.enabled)
        {
            mainCamera.enabled = true;
            camera[index].enabled = false;
        }
    }
}
