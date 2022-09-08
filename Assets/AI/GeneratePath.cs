using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePath : MonoBehaviour
{
    [SerializeField] private Transform doorWaypoint;
    [SerializeField] private List<Transform> waypoints = new List<Transform>();
    [SerializeField] private Transform waypointParent;
    [SerializeField] private Transform currentWaypoint;

    private AIPathFinding aI;

    private void Start()
    {
        aI = FindObjectOfType<AIPathFinding>();
        CheckForWaypoints();
    }

    private void CheckForWaypoints()
    {
        foreach (Transform child in waypointParent)
        {
            waypoints.Add(child);
        }
    }

    public void GenPath(AIPathFinding aI)
    {
        Transform destination = waypoints[Random.Range(0, waypoints.Count)];
        currentWaypoint = destination;
        aI.GetWaypoint(destination);
    }

    public void AddDoorWaypoint()
    {
        doorWaypoint.parent = waypointParent;
        waypoints.Add(doorWaypoint);
    }
}
