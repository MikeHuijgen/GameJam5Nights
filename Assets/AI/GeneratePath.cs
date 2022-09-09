using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePath : MonoBehaviour
{
    [SerializeField] private Transform doorWaypoint;
    [SerializeField] private Transform waypointParent;
    [SerializeField] private Transform aiParent;
    [SerializeField] private Transform currentWaypoint;
    [SerializeField] private List<Transform> waypoints = new List<Transform>();
    [SerializeField] private List<Transform> aIList = new List<Transform>();

    private AIPathFinding aI;
    private bool batteryDied = false;

    private void Start()
    {
        aI = FindObjectOfType<AIPathFinding>();
        CheckForWaypoints();
        CheckForAi();
    }

    private void CheckForAi()
    {
        foreach (Transform child in aiParent)
        {
            aIList.Add(child);
        }
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

    public void BatteryHasDied()
    {
        GetRandomAI();
    }

    private void GetRandomAI()
    {
        //It gets a random Ai out of the list and let him go to the door
        Transform randomAi = aIList[Random.Range(0, aIList.Count)];
        foreach (Transform child in aIList)
        {
            child.gameObject.SetActive(false);
        }
        randomAi.gameObject.SetActive(true);
        randomAi.GetComponent<AIPathFinding>().GoKillThePLayer();
        randomAi.GetComponent<AIPathFinding>().GetWaypoint(doorWaypoint);
    }
}
