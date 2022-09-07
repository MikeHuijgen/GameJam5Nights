using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float gameTime;
    [SerializeField] private float addWaypointTime;
    [SerializeField] private Transform doorWaypoint;
    private AIPathFinding aI;
    private bool hasAddWaypoint = false;

    private void Awake()
    {
        aI = FindObjectOfType<AIPathFinding>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameTime();
    }

    private void CheckGameTime()
    {
        gameTime += Time.deltaTime;

        if (gameTime >= addWaypointTime && !hasAddWaypoint)
        {
            aI.AddDoorWaypoint();
            hasAddWaypoint = true;
        }
    }
}
