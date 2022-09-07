using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIPathFinding : MonoBehaviour
{
    [SerializeField] private float desChangeTime;
    [SerializeField] private List<Transform> waypoints = new List<Transform>();
    [SerializeField] private Transform waypointParent;
    [SerializeField] private Transform doorWaypoint;

    private float currentDesTime;
    private Transform currentWaypoint;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        currentDesTime = desChangeTime;
        CheckForWaypoints();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        GetWaypoint();
    }

    private void CheckForWaypoints()
    {
        foreach (Transform child in waypointParent)
        {
            waypoints.Add(child);
        }
    }

    private void GetWaypoint()
    {
        currentDesTime -= Time.deltaTime;
        if (currentDesTime <= 0)
        {
            Transform destination = waypoints[Random.Range(0, waypoints.Count)];
            currentWaypoint = destination;
            agent.SetDestination(destination.position);
            currentDesTime = desChangeTime;
        }
    }

    public void AddDoorWaypoint()
    {
        waypoints.Add(doorWaypoint);
    }
}
