using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float gameTime;
    [SerializeField] private float addWaypointTime;
    private GeneratePath generatePath;
    private bool hasAddWaypoint = false;

    private void Awake()
    {
        generatePath = FindObjectOfType<GeneratePath>();
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
            generatePath.AddDoorWaypoint();
            hasAddWaypoint = true;
        }
    }
}
