using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class CrossHairMovement : MonoBehaviour
{
    [SerializeField] Image crossHairColor;
    [SerializeField] GameObject door; 
    [SerializeField] float horizontalSpeed = 5.0f;

    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);
    }
}
