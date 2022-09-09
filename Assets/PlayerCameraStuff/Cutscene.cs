using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{

    //Code uitzetten : "outline - colorchangecrosshair - crosshairmovement".
    //Als je op de deur klikt begint de animatie. Niet aan het begin van de game. 


    [SerializeField] Outline outline;
    [SerializeField] ColorChangeCrossHair colorChange;
    [SerializeField] CrossHairMovement hairMovement;

    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        
    }
}
