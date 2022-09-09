using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    [SerializeField] Animator animator;

    //scripts 
    [SerializeField] Outline outline;
    [SerializeField] ColorChangeCrossHair colorChange;
    [SerializeField] CrossHairMovement crossMovement;
    private void Awake()
    {
        animator.enabled = false;
    }
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        ToDoor();
        ToChair();
    }

    void ToDoor()
    {
        if (Input.GetKey(KeyCode.A))
        {
            animator.enabled = true;
            animator.SetTrigger("ToTheDoor");
            outline.enabled = false;
            colorChange.enabled = false;
            crossMovement.enabled = false;
        }
        if (Input.GetMouseButton(0))
        {
            animator.enabled = true;
            animator.SetTrigger("ToTheDoor");
            outline.enabled = false;
            colorChange.enabled = false;
            crossMovement.enabled = false;
        }
        else
        {
            outline.enabled = true;
            colorChange.enabled = true;
            crossMovement.enabled = true;
        }
    }
    void ToChair()
    {
        if (Input.GetKey(KeyCode.D))
        {
            animator.enabled = true;
            animator.SetTrigger("ToTheChair");
            outline.enabled = false;
            colorChange.enabled = false;
            crossMovement.enabled = false;
        }
        if (Input.GetMouseButton(0))
        {
            animator.enabled = true;
            animator.SetTrigger("ToTheDoor");
            outline.enabled = false;
            colorChange.enabled = false;
            crossMovement.enabled = false;
        }
        else
        {
            outline.enabled = true;
            colorChange.enabled = true;
            crossMovement.enabled = true;
        }
    }
}
