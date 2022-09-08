using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIPathFinding : MonoBehaviour
{
    [Header("AI Settings")]
    [Tooltip("Change the time the AI gets a new destination")]
    [SerializeField][Range(1,20)] private float changeWaypointTime;
    [SerializeField] private float changeDestinationTime;

    [SerializeField] private float currentDesTime;
    private Transform currentWaypoint;
    private NavMeshAgent agent;
    private GeneratePath generatePath;
    private GameManager gameManager;

    private bool timeHasChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        generatePath = FindObjectOfType<GeneratePath>();
        currentDesTime = changeWaypointTime;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimeForNewWaypoint();
        ChangeDestinationTime();
    }

    private void CheckTimeForNewWaypoint()
    {
        currentDesTime -= Time.deltaTime;
        if (currentDesTime <= 0)
        {
            generatePath.GenPath(this);
            currentDesTime = changeWaypointTime;
        }
    }

    public void GetWaypoint(Transform waypoint)
    {
        agent.SetDestination(waypoint.position);
    }

    private void ChangeDestinationTime()
    {
        if (gameManager.gameTime > changeDestinationTime && !timeHasChanged)
        {
            timeHasChanged = true;
            changeWaypointTime /= 2; 
        }
    }
}
