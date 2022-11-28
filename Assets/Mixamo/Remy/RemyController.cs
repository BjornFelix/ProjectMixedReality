using System;
using UnityEngine;

public class RemyController : MonoBehaviour
{
    //var for walking
    float speed = 1.2f;

    //var for animations
    Animator animator;

    //Target to stand in front of class
    public Transform blackboard;

    //Target to sit
    public Transform chair;

    //Target to enter class
    public Transform doorEnter;
    public Transform doorIn;

    public Transform nextToChair;

    //Temp code tibe
    public RemyState State = RemyState.Idle;
    public RemyPosition Position = RemyPosition.Start;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Remt: " + State);
        switch (State)
        {
            case RemyState.GoSitting:
                Sit();
                break;
            case RemyState.GoWalking:
                Walk();
                break;
            case RemyState.Walking:
                switch (Position)
                {
                    case RemyPosition.Start:

                        break;
                    case RemyPosition.Chair:
                        if (GoTo(chair))
                        {
                            //Change state to Idle (in scenario check if state idle gosit
                            this.State = RemyState.GoIdle;
                        }

                        break;
                    case RemyPosition.Blackboard:
                        if (GoTo(blackboard))
                        {
                            //Change state to Idle (in scenario check if state idle gowave or gopoint)
                            this.State = RemyState.GoIdle;
                        }
                        break;
                    case RemyPosition.DoorEnter:
                        if (GoTo(doorEnter))
                        {
                            //Change state to Idle (in scenario check if state idl e gowave or gopoint) 
                            this.State = RemyState.GoIdle;
                        }
                        break;
                    case RemyPosition.NextToChair:
                        if (GoTo(nextToChair))
                        {
                            //Change state to Idle (in scenario check if state idle gowave or gopoint) 
                            this.State = RemyState.GoIdle;
                        }
                        break;
                    case RemyPosition.DoorIn:
                        if (GoTo(doorIn))
                        {
                            //Change state to Idle (in scenario check if state idle gowave or gopoint) 
                            this.State = RemyState.GoIdle;
                        }
                        break;
                    default:
                        break;
                }

                break;
            case RemyState.GoStand:
                Stand();
                break;
            case RemyState.GoWaving:
                Wave();
                break;
            case RemyState.GoPointing:
                Point();
                break;
            case RemyState.GoIdle:
                Idle();
                break;
            case RemyState.GoTalking:
                Talk();
                break;
        }
    }

    #region StateMethods
    private void Talk()
    {
        ResetAllTriggers();
        animator.SetTrigger("Talk");
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        State = RemyState.Talking;
    }
    private void Walk()
    {
        ResetAllTriggers();
        animator.SetTrigger("Walk");
        State = RemyState.Walking;
    }
    private void Idle()
    {
        ResetAllTriggers();
        animator.SetTrigger("Idle");
        State = RemyState.Idle;
    }

    private void Point()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animator.ResetTrigger("Up");
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            animator.SetTrigger("Point");
        }
        State = RemyState.Pointing;
    }
    private void Wave()
    {

        ResetAllTriggers();
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        animator.SetTrigger("Wave");

        State = RemyState.Waving;
    }

    private void Stand()
    {

        ResetAllTriggers();
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        animator.SetTrigger("Up");

        State = RemyState.Standing;

    }
    private void Sit()
    {
        // if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))

        ResetAllTriggers();
        //Turn to class
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            //Sit down
            animator.SetTrigger("Sit");
        
        //Change state to sitting
        this.State = RemyState.Sitting;

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

    private void IsIdle()
    {
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Breathing Idle")
        {
            State = RemyState.GoIdle;
        }
    }

    private bool GoTo(Transform target)
    {
        if (Vector3.Distance(transform.position, target.position) > 0.01)
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
