using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIPathFinding : MonoBehaviour
{
    [Header("AI Settings")]
    [SerializeField][Range(1,20)] private float desChangeTime;

    [SerializeField] private float currentDesTime;
    private Transform currentWaypoint;
    private NavMeshAgent agent;
    private GeneratePath generatePath;

    // Start is called before the first frame update
    void Start()
    {
        generatePath = FindObjectOfType<GeneratePath>();
        currentDesTime = desChangeTime;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimeForNewWaypoint();
    }

    private void CheckTimeForNewWaypoint()
    {
        currentDesTime -= Time.deltaTime;
        if (currentDesTime <= 0)
        {
            generatePath.GenPath(this);
            currentDesTime = desChangeTime;
        }
    }

    public void GetWaypoint(Transform waypoint)
    {
        agent.SetDestination(waypoint.position);
    }
}
