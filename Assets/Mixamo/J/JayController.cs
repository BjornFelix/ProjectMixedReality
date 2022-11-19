using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JayController : MonoBehaviour
{
    //var for walking
    float speed = 1.2f;

    //var for animations
    Animator animator;

    //Target to stand in front of class
    public Transform blackboard;

    //Target to sit
    public Transform chair;
    public Transform row;

    //Target to enter class
    public Transform doorEnter;

    //Temp code tibe
    public JayState State = JayState.Idle;
    public JayPosition Position = JayPosition.Start;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        //if (animator != null)
        //{

        ////    animator.SetTrigger("Walk");
        //}
        // SetTarget(new Vector3(targets[currentTransform].position.x, transform.position.y, targets[currentTransform].position.z));
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log(State);
        switch (State)
        {
            case JayState.GoSitting:
                Sit();
                break;
            case JayState.GoWalking:
                Walk();
                break;
            case JayState.Walking:
                switch (Position)
                {
                    case JayPosition.Start:

                        break;
                    case JayPosition.Chair:
                        if (GoTo(chair))
                        {
                            //Change state to Idle (in scenario check if state idle gosit
                            this.State = JayState.GoIdle;
                        }

                        break;
                    case JayPosition.Blackboard:
                        if (GoTo(blackboard))
                        {
                            //Change state to Idle (in scenario check if state idle gowave or gopoint)
                            this.State = JayState.GoIdle;
                        }
                        break;
                    case JayPosition.DoorEnter:
                        if (GoTo(doorEnter))
                        {
                            //Change state to Idle (in scenario check if state idle gowave or gopoint) 
                            this.State = JayState.GoIdle;
                        }

                        break;
                    case JayPosition.Row:
                        if (GoTo(row))
                        {
                            this.State = JayState.GoIdle;
                        }
                        break;
                    default:
                        break;
                }

                break;
            case JayState.GoStand:
                Stand();
                break;
            case JayState.GoWaving:
                Wave();
                break;
            //case JayState.GoPoint:
            //    Point();
            //    break;
            case JayState.GoAskQuestion:
                AskQuestion();
                break;
            case JayState.GoIdle:
                Idle();
                break;
            case JayState.GoPickUp:
                PickUp();
                break;

        }


    }






    #region 
    private void PickUp()
    {
        ResetAllTriggers();
        transform.rotation = Quaternion.Euler(0f,90f, 0f);
        animator.SetTrigger("PickUp");
        State = JayState.PickingUp;
    }
    private void AskQuestion()
    {
        ResetAllTriggers();
        animator.SetTrigger("AskQuestion");
        State = JayState.AskingQuestion;
    }

    private void Walk()
    {
        ResetAllTriggers();
        animator.SetTrigger("Walk");
        State = JayState.Walking;
    }

    private void Idle()
    {
        ResetAllTriggers();
        animator.SetTrigger("Idle");
        State = JayState.Idle;
    }

    private void Point()
    {

        ResetAllTriggers();
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        animator.SetTrigger("Point");

        State = JayState.Pointing;
    }
    private void Wave()
    {
        ResetAllTriggers();

        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        animator.SetTrigger("Wave");

        State = JayState.Waving;
    }

    private void Stand()
    {
        ResetAllTriggers();

        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        animator.SetTrigger("Up");

        State = JayState.Standing;

    }
    private void Sit()
    {
        ResetAllTriggers();
        //Turn to class
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //Sit down
        animator.SetTrigger("Sit");

        //Change state to sitting
        this.State = JayState.Sitting;

    }
    #endregion

    #region HelperMethods

    private void ResetAllTriggers()
    {
        foreach (var param in animator.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Trigger)
            {
                animator.ResetTrigger(param.name);
            }
        }
    }



    private bool GoTo(Transform target)
    {
        if (Vector3.Distance(transform.position, target.position) > 0.2)
        {
            transform.LookAt(target.position);
            Vector3 direction = target.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            return false;
        }
        else
        {
            ResetAllTriggers();
            return true;
        }


    }
    #endregion


}
