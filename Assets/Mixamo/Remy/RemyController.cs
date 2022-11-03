using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemyController : MonoBehaviour
{
    string state = "WALKING";

    //var for walking
    public Transform[] targets;
    float speed = 1.2f;
    private int currentTransform = 0;

    //var for animations
    Animator animator;

    //Target to stand in front of class

    public Transform blackboard;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("Walk");
        }
        // SetTarget(new Vector3(targets[currentTransform].position.x, transform.position.y, targets[currentTransform].position.z));
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case "WALKING":
                if (Vector3.Distance(transform.position, targets[currentTransform].position) > 0.2)
                {
                    Vector3 direction = targets[currentTransform].position - transform.position;
                    transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

                    //Vector3 pos = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                    //GetComponent<Rigidbody>().MovePosition(pos);
                }
                else
                {
                    if (currentTransform + 1 < targets.Length)
                    {
                        currentTransform++;
                        transform.LookAt(targets[currentTransform].position);
                    }
                    else
                    {

                        state = "SITTING";

                        animator.SetTrigger("Sit");

                    }



                    //SetTarget(new Vector3(targets[currentTransform + 1].position.x, transform.position.y, targets[currentTransform + 1].position.z));
                }
                break;
            case "SITTING":
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                if (Input.GetKey(KeyCode.U) && Input.GetKey(KeyCode.R))
                {
                    state = "STANDUP";
                    animator.SetTrigger("Up");

                }

                break;
            case "STANDUP":

                if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.R))
                {
                    state = "SITTING";

                    animator.SetTrigger("Sit");
                }
                if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.R))
                {

                    state = "WAVE";
                    animator.SetTrigger("Walk");

                }
                else
                {

                    animator.ResetTrigger("Sit");
                }

                break;
            case "WAVE":
                if (Vector3.Distance(transform.position, blackboard.position) > 0.2)
                {
                   
                    transform.LookAt(blackboard.position);
                    Vector3 direction = blackboard.position - transform.position;
                    transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

                    //Vector3 pos = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                    //GetComponent<Rigidbody>().MovePosition(pos);
                }
                else
                {
                    animator.ResetTrigger("Walk");
                    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                    animator.SetTrigger("Wave");
                    state = "kijhugy";
                }
                break;
            default:
                //animator.SetTrigger("Stop");
                break;
        }





    }
}
