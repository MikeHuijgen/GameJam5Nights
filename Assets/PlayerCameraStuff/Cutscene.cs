using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    [SerializeField] Animator animator;
    Animation animation; 

    //scripts 
    [SerializeField] Outline outline;
    [SerializeField] ColorChangeCrossHair colorChange;
    [SerializeField] CrossHairMovement crossMovement;


    private bool animationFinished = false; 

    private void Awake()
    {
        animator.enabled = false;
    }
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animation = GetComponent<Animation>();
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
            CheckAnimatorState();
        }
    }

    void ToChair()
    {
        if (Input.GetKey(KeyCode.D))
        {
            animator.enabled = true;
            animator.SetTrigger("ToTheChair");
            CheckAnimatorState();
        }
    }

    void CheckAnimatorState()
    {
        AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float Ntime = animatorStateInfo.normalizedTime; 
        if(Ntime > 1.0f && animationFinished == false)
        {
            animationFinished = true;
            Debug.Log(Ntime);
            Ntime = 0;
            Debug.Log(Ntime);
            Debug.Log(animationFinished);
            animator.enabled = false;
        }
    }
}
