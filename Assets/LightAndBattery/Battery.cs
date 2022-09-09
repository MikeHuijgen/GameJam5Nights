using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    [Header("Battery Settings")]
    [SerializeField][Range(0,100)] private int batteryProcent;
    [SerializeField] private float decreaseBatterytime;
    [SerializeField] public bool lightIsOn = false;
    [Header("BatteryBar Settings")]
    [SerializeField] private Slider batteryBar;
    [SerializeField] private Image batteryFill;
    [SerializeField] private Gradient fillGradient;

    private HallLight hallLight;
    private float currentBatteryTime;
    private bool batteryDied = false;

    // Start is called before the first frame update
    void Start()
    {
        batteryFill.color = fillGradient.Evaluate(1f);
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
                UpdateBatteryBar();
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
            DigitaleClock clock = FindObjectOfType<DigitaleClock>();

            clock.BatteryDied();
            hallLight.BatteryHasDied();
            generatePath.BatteryHasDied();
        }
    }

    private void UpdateBatteryBar()
    {
        batteryFill.color = fillGradient.Evaluate(batteryBar.normalizedValue);
        batteryBar.value = batteryProcent;
    }
}
