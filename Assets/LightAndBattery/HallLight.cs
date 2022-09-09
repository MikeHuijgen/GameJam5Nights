using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallLight : MonoBehaviour
{
    private Battery battery;
    private Light hallLight;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        battery = FindObjectOfType<Battery>();
        hallLight = GetComponent<Light>();
    }

    private void Update()
    {
        TurnLightOnAndOff();
        CheckForLightOn();
    }

    private void TurnLightOnAndOff()
    {
        //Dit is debug code uiteindelijk moet hier de code als je op een knop druk dat het licht aan en uit gaat
        if (Input.GetKeyDown(KeyCode.L))
        {
            audioSource.Stop();
            hallLight.enabled = !hallLight.enabled;
            audioSource.Play();
        }
    }

    private void CheckForLightOn()
    {
        if (hallLight.enabled)
        {
            battery.lightIsOn = true;
        }
        else
        {
            battery.lightIsOn = false;
        }
    }

    public void BatteryHasDied()
    {
        hallLight.enabled = false;
        battery.lightIsOn = false;
        HallLight lightScript = GetComponent<HallLight>();
        lightScript.enabled = false;
    }
}
