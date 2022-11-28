using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikeController : MonoBehaviour
{
    //var for walking
    float speed = 1.2f;

    //var for animations
    Animator animator;
    AudioSource audioData;

    //Target to stand in front of class
    public Transform blackboard;
    GetBook getBook;
    //Target to sit
    public Transform chair;
    public Transform row;
    public Transform backPack;
    public Transform nextToChair;


    //Target to enter class
    public Transform doorEnter;

    //var to control state and position
    public MikeState State = MikeState.Idle;
    public MikePosition Position = MikePosition.Start;


    // Start is called before the first frame update
    void Start()
    {
        getBook = GetComponent<GetBook>();

        animator = gameObject.GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();
        //if (animator != null)
        //{

        ////    animator.SetTrigger("Walk");
        //}
        // SetTarget(new Vector3(targets[currentTransform].position.x, transform.position.y, targets[currentTransform].position.z));
    }

    // Update is called once per frame
    void Update()
    {
        PlaySounds();
        //IsIdle();
        Debug.Log("Mike: " + State);
        switch (State)
        {
            case MikeState.GoSitting:
                Sit();
                break;
            case MikeState.GoWalking:
                Walk();
                break;
            case MikeState.Walking:
                switch (Position)
                {
                    case MikePosition.Start:

                        break;
                    case MikePosition.Chair:
                        if (GoTo(chair))
                        {
                            //Change state to Idle (in scenario check if state idle gosit
                            this.State = MikeState.GoIdle;
                        }

                        break;
                    case MikePosition.Blackboard:
                        if (GoTo(blackboard))
                        {
                            //Change state to Idle (in scenario check if state idle gowave or gopoint)
                            this.State = MikeState.GoIdle;
                        }
                        break;
                    case MikePosition.DoorEnter:
                        if (GoTo(doorEnter))
                        {
                            //Change state to Idle (in scenario check if state idle gowave or gopoint) 
                            this.State = MikeState.GoIdle;
                        }

                        break;
                    case MikePosition.Row:
                        if (GoTo(row))
                        {
                            this.State = MikeState.GoIdle;
                        }
                        break;
                    case MikePosition.BackPack:
                        if (GoTo(backPack))
                        {

                            this.State = MikeState.GoIdle;
                        }
                        break;
                    case MikePosition.NextToChair:
                        if (GoTo(nextToChair))
                        {

                            this.State = MikeState.GoIdle;
                        }
                        break;
                    default:
                        break;
                }

                break;
            case MikeState.GoStand:
                Stand();
                break;
            case MikeState.GoWaving:
                Wave();
                break;
            case MikeState.GoPoint:
                Point();
                break;
            case MikeState.GoAskQuestion:
                AskQuestion();
                break;
            case MikeState.GoIdle:
                Idle();
                break;
            case MikeState.GoPickUp:
                PickUp();
                break;
            case MikeState.goGive:
                Give();
                break;
        }


    }





    #region StateMethods
    private void Give()
    {
        ResetAllTriggers();
        animator.SetTrigger("Give");
        State = MikeState.Giving;
    }

    private void PickUp()
    {
        ResetAllTriggers();
        animator.SetTrigger("PickUp");
        State = MikeState.PickingUp;
    }
    private void AskQuestion()
    {
        ResetAllTriggers();
        animator.SetTrigger("AskQuestion");
        State = MikeState.AskingQuestion;
    }

    private void Walk()
    {
        ResetAllTriggers();
        animator.SetTrigger("Walk");
        State = MikeState.Walking;
    }

    private void Idle()
    {
        ResetAllTriggers();
        animator.SetTrigger("Idle");
        State = MikeState.Idle;
    }

    private void Point()
    {

        ResetAllTriggers();
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        animator.SetTrigger("Point");

        State = MikeState.Pointing;
    }
    private void Wave()
    {
        ResetAllTriggers();

        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        animator.SetTrigger("Wave");

        State = MikeState.Waving;
    }

    private void Stand()
    {
        ResetAllTriggers();

        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        animator.SetTrigger("Up");

        State = MikeState.Standing;

    }
    private void Sit()
    {
        ResetAllTriggers();
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        animator.SetTrigger("Sit");
        this.State = MikeState.Sitting;

    }
    #endregion

    #region HelperMethods

    public void GetBookFromTable()
    {
        getBook.getBook();
    }
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
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Breathing Idle" && State != MikeState.Idle && State != MikeState.GoIdle && State == MikeState.PickingUp)
        {
            State = MikeState.GoIdle;
        }
    }

    private void PlaySounds()
    {
        if (State == MikeState.Walking)
        {

            audioData.Play(0);
        }
        else
        {
            audioData.Stop();

        }
    }


    private bool GoTo(Transform target)
    {
        if (Vector3.Distance(transform.position, target.position) > 0.05)
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


    //private void SetTarget(Vector3 newTarget)
    //{
    //    target = newTarget;
    //    transform.LookAt(target);

    //}
}
