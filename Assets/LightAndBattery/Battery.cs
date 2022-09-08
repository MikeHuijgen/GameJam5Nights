using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField][Range(0,100)] private int batteryProcent;
    [SerializeField] private float decreaseBatterytime;
    [SerializeField] public bool lightIsOn = false;
    [SerializeField] private Transform aiParent;

    private HallLight hallLight;
    private float currentBatteryTime;
    private bool batteryDied = false;

    // Start is called before the first frame update
    void Start()
    {
        batteryProcent = 100;
        currentBatteryTime = decreaseBatterytime;
        hallLight = FindObjectOfType<HallLight>();
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseBattery();
        BatteryDied();
    }

    private void DecreaseBattery()
    {
        if(!batteryDied)
        {
            currentBatteryTime -= Time.deltaTime;
            if (lightIsOn && currentBatteryTime <= 0)
            {
                batteryProcent--;
                currentBatteryTime = decreaseBatterytime;
            }
        }
    }
     
    private void BatteryDied()
    {
        if (batteryProcent <= 0 && !batteryDied)
        {
            batteryDied = true;
            GeneratePath generatePath = FindObjectOfType<GeneratePath>();

            hallLight.BatteryHasDied();
            generatePath.BatteryHasDied();
        }
    }
}
