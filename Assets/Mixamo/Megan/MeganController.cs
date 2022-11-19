using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeganController : MonoBehaviour
{
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
    public MeganState State = MeganState.Idle;
    public MeganPosition Position = MeganPosition.Start;


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
       // Debug.Log(State);
        switch (State)
        {
            case MeganState.GoSitting:
                Sit();
                break;
            case MeganState.GoWalking:
                Walk();
                break;
            case MeganState.Walking:
                switch (Position)
                {
                    case MeganPosition.Start:

                        break;
                    case MeganPosition.Chair:
                        if (GoTo(chair))
                        {
                            //Change state to Idle (in scenario check if state idle gosit
                            this.State = MeganState.GoIdle;
                        }

                        break;
                    case MeganPosition.Blackboard:
                        if (GoTo(blackboard))
                        {
                            //Change state to Idle (in scenario check if state idle gowave or gopoint)
                            this.State = MeganState.GoIdle;
                        }
                        break;
                    case MeganPosition.DoorEnter:
                        if (GoTo(doorEnter))
                        {
                            //Change state to Idle (in scenario check if state idle gowave or gopoint) 
                            this.State = MeganState.GoIdle;
                        }

                        break;
                    case MeganPosition.Row:
                        if (GoTo(row))
                        {
                            this.State = MeganState.GoIdle;
                        }
                        break;
                    default:
                        break;
                }

                break;
            case MeganState.GoStand:
                Stand();
                break;
            case MeganState.GoWaving:
                Wave();
                break;
            //case MeganState.GoPoint:
            //    Point();
            //    break;
            case MeganState.GoAskQuestion:
                AskQuestion();
                break;
            case MeganState.GoIdle:
                Idle();
                break;
            case MeganState.GoPickUp:
                PickUp();
                break;
        }


    }




    #region StateMethods
    private void AskQuestion()
    {
        ResetAllTriggers();
        animator.SetTrigger("AskQuestion");
        State = MeganState.AskingQuestion;
    }

    private void Walk()
    {
        ResetAllTriggers();
        animator.SetTrigger("Walk");
        State = MeganState.Walking;
    }

    private void Idle()
    {
        ResetAllTriggers();
        animator.SetTrigger("Idle");
        State = MeganState.Idle;
    }

    private void Point()
    {

        ResetAllTriggers();
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        animator.SetTrigger("Point");

        State = MeganState.Pointing;
    }
    private void Wave()
    {
        ResetAllTriggers();

        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        animator.SetTrigger("Wave");

        State = MeganState.Waving;
    }

    private void Stand()
    {
        ResetAllTriggers();

        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        animator.SetTrigger("Up");

        State = MeganState.Standing;

    }
    private void Sit()
    {
        ResetAllTriggers();
        //Turn to class
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //Sit down
        animator.SetTrigger("Sit");

        //Change state to sitting
        this.State = MeganState.Sitting;

    }
    private void PickUp()
    {
        ResetAllTriggers();
        transform.rotation = Quaternion.Euler(0f, -90f, 0f);

        animator.SetTrigger("PickUp");
        State = MeganState.PickingUp;
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
