using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CameraSwitch : MonoBehaviour
{
    Renderer screen;
    public Material cameraOff;
    public Material cameraStatic;

    VideoPlayer staticEffect;

    bool canSwitch = false;

    public List<Material> materials = new List<Material>();
    int index = 0;

    IEnumerator ledTimer;

    public GameObject LED1;
    public GameObject LED2;
    public GameObject LED3;

    public Material On;
    public Material Off;

    public List<string> overheatedCameras = new List<string>();

    public TMPro.TextMeshPro cameraNumber;

    void Start()
    {
        screen = GetComponent<Renderer>();
        screen.material = cameraOff;
        cameraNumber.faceColor = Color.black;

        staticEffect = GetComponent<VideoPlayer>();

        ledTimer = LEDTimer();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            canSwitch = true;
            screen.material = materials[index];
            cameraNumber.faceColor = Color.white;

            StartCoroutine(ledTimer);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StopCoroutine(ledTimer);

            LED1.GetComponent<Renderer>().material = Off;
            LED2.GetComponent<Renderer>().material = Off;
            LED3.GetComponent<Renderer>().material = Off;

            canSwitch = false;
            cameraNumber.faceColor = Color.black;
            screen.material = cameraOff;

            ledTimer = LEDTimer();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && canSwitch)
        {
            StopCoroutine(ledTimer);

            LED1.GetComponent<Renderer>().material = Off;
            LED2.GetComponent<Renderer>().material = Off;
            LED3.GetComponent<Renderer>().material = Off;

            if (index >= materials.Count - 1)
            {
                index = 0;
                screen.material = materials[index];
            }
            else
            {
                index++;
                screen.material = materials[index];
            }

            ledTimer = LEDTimer();
            StartCoroutine(ledTimer);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && canSwitch)
        {
            StopCoroutine(ledTimer);

            LED1.GetComponent<Renderer>().material = Off;
            LED2.GetComponent<Renderer>().material = Off;
            LED3.GetComponent<Renderer>().material = Off;

            if (index <= 0)
            {
                index = materials.Count - 1;
                screen.material = materials[index];
            }
            else
            {
                index--;
                screen.material = materials[index];
            }

            ledTimer = LEDTimer();
            StartCoroutine(ledTimer);
        }

        cameraNumber.text = (index + 1).ToString();

        if (overheatedCameras.Contains(materials[index].name))
        {
            staticEffect.Play();
            screen.material = cameraStatic;
        }
        else if (canSwitch)
        {
            screen.material = materials[index];
            staticEffect.Stop();
        }
    }

    IEnumerator LEDTimer()
    {
        yield return new WaitForSeconds(1);
        LED1.GetComponent<Renderer>().material = On;

        yield return new WaitForSeconds(1);
        LED2.GetComponent<Renderer>().material = On;

        yield return new WaitForSeconds(1);
        LED3.GetComponent<Renderer>().material = On;

        yield return new WaitForSeconds(1);
        overheatedCameras.Add(materials[index].name);
        StartCoroutine(OverheatCooldown());

        LED1.GetComponent<Renderer>().material = Off;
        LED2.GetComponent<Renderer>().material = Off;
        LED3.GetComponent<Renderer>().material = Off;

        ledTimer = LEDTimer();
        StartCoroutine(ledTimer);
    }

    IEnumerator OverheatCooldown()
    {
        yield return new WaitForSeconds(10);
        overheatedCameras.RemoveAt(0);
    }
}
