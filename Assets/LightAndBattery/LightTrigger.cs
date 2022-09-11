using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    [SerializeField] private Light hallLight;

    private AIPathFinding aI;
    private GeneratePath generatePath;
    [SerializeField] private bool aiRunAway = false;
    private BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        generatePath = FindObjectOfType<GeneratePath>();
    }

    private void Update()
    {
        EnableCollider();
    }

    private void EnableCollider()
    {
        if (hallLight.enabled)
        {
            boxCollider.enabled = true;
        }
        else
        {
            boxCollider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            aI = other.GetComponent<AIPathFinding>();
            generatePath.GenPath(aI);
            Debug.Log("Enter");
            aiRunAway = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Debug.Log("ghone");
            aiRunAway = false;
        }
    }
}
