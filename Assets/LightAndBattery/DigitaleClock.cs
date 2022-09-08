using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DigitaleClock : MonoBehaviour
{
    [SerializeField] private TMP_Text ClockText;
    [SerializeField] private int hourInt;
    [SerializeField] private int minuteInt;
    [SerializeField][Range(0.01f,1f)] private float secondTime;

    private float resetTime;
    private bool youWon = false;

    private GameManager gameManager;
    private void Start()
    {
        resetTime = secondTime;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        UpdateClock();
        EndTime();
    }

    private void UpdateClock()
    {
        if (!youWon)
        {
            resetTime -= Time.deltaTime;
            if (resetTime <= 0)
            {
                minuteInt++;
                resetTime = secondTime;
            }

            if (minuteInt < 10)
            {
                ClockText.text = $"{hourInt}:0{minuteInt}";
            }

            if (minuteInt >= 10)
            {
                ClockText.text = $"{hourInt}:{minuteInt}";
            }

            if (minuteInt >= 60)
            {
                hourInt++;
                minuteInt = 0;
            }
        }
    }

    private void EndTime()
    {
        if (hourInt >= 22 && !youWon)
        {
            ClockText.text = $"{hourInt}:0{minuteInt}";
            youWon = true;
            Debug.Log("You won");
        }
    }
}
