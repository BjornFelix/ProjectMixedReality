using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemyScenario : MonoBehaviour
{

    private RemyController remyController;

    void Start()
    {
        remyController = gameObject.GetComponent<RemyController>();
        StartCoroutine(Scenario());
    }

    private IEnumerator Scenario()
    {
        if (remyController != null)
        {
            //Walk to door
            remyController.State = RemyState.GoWalking; //Start walking animation.

            yield return StartCoroutine(WaitUntilWalking());

            remyController.Position = RemyPosition.DoorEnter;  //Tell Remy where he has to walk to, state will be set to Idle when target is reached.

            yield return StartCoroutine(WaitUntilIdle());

            remyController.State = RemyState.GoWalking; //Start walkign animation.

            yield return StartCoroutine(WaitUntilWalking());

            remyController.Position = RemyPosition.Chair;  //Tell Remy where he has to walk to, state will be set to Idle when target is reached.

            yield return StartCoroutine(WaitUntilIdle());

            remyController.State = RemyState.GoSitting; // animation sit wil start

        }
    }

    IEnumerator WaitUntilWalking()
    {
        yield return new WaitUntil(() => remyController.State == RemyState.Walking);

    }

    IEnumerator WaitUntilIdle()
    {
        yield return new WaitUntil(() => remyController.State == RemyState.Idle);

    }
    // Update is called once per frame
    //void Update()
    //{


    //    if (remyController != null)
    //    {
    //        //Walk to door
    //        remyController.State = RemyState.GoWalking; //Start walking animation.
    //        // WaitUntil(remyController.State == RemyState.Walking)

    //        remyController.Position = RemyPosition.DoorEnter;  //Tell Remy where he has to walk to, state will be set to Idle when target is reached.

    //        //WaitUntil(remyController.State == RemyState.Idle)

    //        //Loop will end when remy has reacher DoorEnter target.

    //        //Walk to chair
    //        remyController.State = RemyState.GoWalking;//Start walkign animation.
    //        //WaitUntil(remyController.State == RemyState.Walking)

    //        remyController.Position = RemyPosition.Chair;  //Tell Remy where he has to walk to, state will be set to Idle when target is reached.


    //        //WaitUntil(remyController.State == RemyState.Idle)
    //        //Loop will end when remy has reached chair.
    //        remyController.State = RemyState.GoSitting; // animation sit wil start


    //    }

    //    //if (remyController.State == RemyState.Sitting)
    //    //{
    //    //    if (Input.GetKey(KeyCode.U) && Input.GetKey(KeyCode.R))
    //    //    {
    //    //        remyController.State = RemyState.GoStand;

    //    //    }
    //    //}
    //    //if (remyController.State == RemyState.Standing || remyController.State == RemyState.Idle)
    //    //{
    //    //    if (Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.R))
    //    //    {
    //    //        remyController.State = RemyState.GoPointing;
    //    //    }
    //    //    if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.R))
    //    //    {
    //    //        remyController.State = RemyState.GoWaving;
    //    //    }
    //    //    if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.R))
    //    //    {
    //    //        remyController.State = RemyState.GoSitting;
    //    //    }


    //    //}
    //    //if (remyController.State == RemyState.Waving || remyController.State == RemyState.Pointing)
    //    //{
    //    //    if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.R))
    //    //    {
    //    //        remyController.State = RemyState.GoIdle;
    //    //    }
    //    //}




    //}

}
