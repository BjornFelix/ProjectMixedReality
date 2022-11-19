using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour
{

    private RemyController remyController;
    private MikeController mikeController;
    private MeganController meganController;
    private JayController jayController;

    public GameObject remy;
    public GameObject mike;
    public GameObject megan;
    public GameObject jay;

    void Start()
    {
        mikeController = mike.GetComponent<MikeController>();
        remyController = remy.GetComponent<RemyController>();
        meganController = megan.GetComponent<MeganController>();
        jayController = jay.GetComponent<JayController>();
        StartCoroutine(StartScenario());
    }


    private IEnumerator StartScenario()
    {
        if (remyController != null)
        {
            #region RemyEnterClass
            // Walk to door
            //remyController.State = RemyState.GoWalking; //Start walking animation.

            //yield return StartCoroutine(WaitUntilWalking(Characters.Remy));

            //remyController.Position = RemyPosition.DoorEnter;  //Tell Remy where he has to walk to, state will be set to Idle when target is reached.

            //yield return StartCoroutine(WaitUntilIdle(Characters.Remy));

            //remyController.State = RemyState.GoWalking; //Start walkign animation.

            //yield return StartCoroutine(WaitUntilWalking(Characters.Remy));

            //remyController.Position = RemyPosition.Blackboard;  //Tell Remy where he has to walk to, state will be set to Idle when target is reached.

            //yield return StartCoroutine(WaitUntilIdle(Characters.Remy));

            //remyController.State = RemyState.GoWaving;

            //yield return StartCoroutine(WaitUntilWaving(Characters.Remy));

            //yield return new WaitForSeconds(6);

            //remyController.State = RemyState.GoIdle;

            //yield return StartCoroutine(WaitUntilIdle(Characters.Remy));

            //yield return new WaitForSeconds(2);

            //remyController.State = RemyState.GoWalking; //Start walking animation.

            //yield return StartCoroutine(WaitUntilWalking(Characters.Remy));

            //remyController.Position = RemyPosition.Chair;  //Tell Remy where he has to walk to, state will be set to Idle when target is reached.

            //yield return StartCoroutine(WaitUntilIdle(Characters.Remy));

            //remyController.State = RemyState.GoSitting; // animation sit wil start

            //yield return StartCoroutine(WaitUntilSitting(Characters.Remy));

            #endregion

            #region MikeEnterClass
            //Walk to door
            mikeController.State = MikeState.GoWalking; //Start walking animation.

            yield return StartCoroutine(WaitUntilWalking(Characters.Mike));

            mikeController.Position = MikePosition.DoorEnter;  //Tell Mike where he has to walk to, state will be set to Idle when target is reached.

            yield return StartCoroutine(WaitUntilIdle(Characters.Mike));

            mikeController.State = MikeState.GoWalking; //Start walkign animation.

            yield return StartCoroutine(WaitUntilWalking(Characters.Mike));

            mikeController.Position = MikePosition.Blackboard;  //Tell Mike where he has to walk to, state will be set to Idle when target is reached.

            yield return StartCoroutine(WaitUntilIdle(Characters.Mike));

            mikeController.State = MikeState.GoWaving;

            yield return StartCoroutine(WaitUntilWaving(Characters.Mike));

            yield return new WaitForSeconds(3);

            mikeController.State = MikeState.GoIdle;

            yield return StartCoroutine(WaitUntilIdle(Characters.Mike));

            mikeController.State = MikeState.GoWalking; //Start walking animation.

            yield return StartCoroutine(WaitUntilWalking(Characters.Mike));

            mikeController.Position = MikePosition.Row;  //Tell Mike where he has to walk to, state will be set to Idle when target is reached.

            yield return StartCoroutine(WaitUntilIdle(Characters.Mike));
            mikeController.State = MikeState.GoWalking; //Start walking animation.

            yield return StartCoroutine(WaitUntilWalking(Characters.Mike));

            mikeController.Position = MikePosition.Chair;  //Tell Mike where he has to walk to, state will be set to Idle when target is reached.
            yield return StartCoroutine(WaitUntilIdle(Characters.Mike));

            mikeController.State = MikeState.GoSitting; // animation sit wil start

            yield return StartCoroutine(WaitUntilSitting(Characters.Mike));

            #endregion

            #region MeganEnterClass
            //Walk to door
            //meganController.State = MeganState.GoWalking; //Start walking animation.

            //yield return StartCoroutine(WaitUntilWalking(Characters.Megan));

            //meganController.Position = MeganPosition.DoorEnter;  //Tell Mike where he has to walk to, state will be set to Idle when target is reached.

            //yield return StartCoroutine(WaitUntilIdle(Characters.Megan));

            //meganController.State = MeganState.GoWalking; //Start walkign animation.

            //yield return StartCoroutine(WaitUntilWalking(Characters.Megan));

            //meganController.Position = MeganPosition.Blackboard;  //Tell Remy where he has to walk to, state will be set to Idle when target is reached.

            //yield return StartCoroutine(WaitUntilIdle(Characters.Megan));

            //meganController.State = MeganState.GoWaving;

            //yield return StartCoroutine(WaitUntilWaving(Characters.Megan));

            //yield return new WaitForSeconds(3);

            //meganController.State = MeganState.GoIdle;

            //yield return StartCoroutine(WaitUntilIdle(Characters.Megan));

            //meganController.State = MeganState.GoWalking; //Start walking animation.

            //yield return StartCoroutine(WaitUntilWalking(Characters.Megan));

            //meganController.Position = MeganPosition.Row;  //Tell Remy where he has to walk to, state will be set to Idle when target is reached.

            //yield return StartCoroutine(WaitUntilIdle(Characters.Megan));
            //meganController.State = MeganState.GoWalking; //Start walking animation.

            //yield return StartCoroutine(WaitUntilWalking(Characters.Megan));

            //meganController.Position = MeganPosition.Chair;  //Tell Remy where he has to walk to, state will be set to Idle when target is reached.
            //yield return StartCoroutine(WaitUntilIdle(Characters.Megan));

            //meganController.State = MeganState.GoSitting; // animation sit wil start

            //yield return StartCoroutine(WaitUntilSitting(Characters.Megan));

            #endregion

            #region JayEnterClass
            ////Walk to door
            //jayController.State = JayState.GoWalking; //Start walking animation.

            //yield return StartCoroutine(WaitUntilWalking(Characters.Jay));

            //jayController.Position = JayPosition.DoorEnter;  //Tell Mike where he has to walk to, state will be set to Idle when target is reached.

            //yield return StartCoroutine(WaitUntilIdle(Characters.Jay));

            //jayController.State = JayState.GoWalking; //Start walkign animation.

            //yield return StartCoroutine(WaitUntilWalking(Characters.Jay));

            //jayController.Position = JayPosition.Blackboard;  //Tell Remy where he has to walk to, state will be set to Idle when target is reached.

            //yield return StartCoroutine(WaitUntilIdle(Characters.Jay));

            //jayController.State = JayState.GoWaving;

            //yield return StartCoroutine(WaitUntilWaving(Characters.Jay));

            //yield return new WaitForSeconds(3);

            //jayController.State = JayState.GoIdle;

            //yield return StartCoroutine(WaitUntilIdle(Characters.Jay));

            //jayController.State = JayState.GoWalking; //Start walking animation.

            //yield return StartCoroutine(WaitUntilWalking(Characters.Jay));

            //jayController.Position = JayPosition.Row;  //Tell Remy where he has to walk to, state will be set to Idle when target is reached.

            //yield return StartCoroutine(WaitUntilIdle(Characters.Jay));
            //jayController.State = JayState.GoWalking; //Start walking animation.

            //yield return StartCoroutine(WaitUntilWalking(Characters.Jay));

            //jayController.Position = JayPosition.Chair;  //Tell Remy where he has to walk to, state will be set to Idle when target is reached.
            //yield return StartCoroutine(WaitUntilIdle(Characters.Jay));

            //jayController.State = JayState.GoSitting; // animation sit wil start

            //yield return StartCoroutine(WaitUntilSitting(Characters.Jay));

            #endregion


            #region GetBook
            //check if everyone is sitting
            //yield return StartCoroutine(WaitUntilSitting(Characters.Jay));
            //yield return StartCoroutine(WaitUntilSitting(Characters.Megan));
            yield return StartCoroutine(WaitUntilSitting(Characters.Mike));
            //yield return StartCoroutine(WaitUntilSitting(Characters.Remy));
            yield return new WaitForSeconds(6);
            //remyController.State = RemyState.GoStand;


            //yield return StartCoroutine(WaitUntilStanding(Characters.Remy));

            //remyController.State = RemyState.GoWalking; //Start walking animation.

            //yield return StartCoroutine(WaitUntilWalking(Characters.Remy));
            //remyController.Position = RemyPosition.Blackboard;  //Tell Remy where he has to walk to, state will be set to Idle when target is reached.

            //yield return StartCoroutine(WaitUntilIdle(Characters.Remy));

            //remyController.State = RemyState.GoTalking;

            //yield return StartCoroutine(WaitUntilTalking(Characters.Remy));




            mikeController.State = MikeState.GoStand;
            meganController.State = MeganState.GoStand;
            jayController.State = JayState.GoStand;

            //yield return StartCoroutine(WaitUntilStanding(Characters.Jay));
            //yield return StartCoroutine(WaitUntilStanding(Characters.Megan));
            yield return StartCoroutine(WaitUntilStanding(Characters.Mike));
            yield return new WaitForSeconds(3);
            mikeController.State = MikeState.GoWalking; //Start walking animation.

            yield return StartCoroutine(WaitUntilWalking(Characters.Mike));

            mikeController.Position = MikePosition.NextToChair;  //Tell Mike where he has to walk to, state will be set to Idle when target is reached.

            yield return StartCoroutine(WaitUntilIdle(Characters.Mike));



            mikeController.State = MikeState.GoWalking; //Start walking animation.

            yield return StartCoroutine(WaitUntilWalking(Characters.Mike));

            mikeController.Position = MikePosition.BackPack;  //Tell Mike where he has to walk to, state will be set to Idle when target is reached.

            yield return StartCoroutine(WaitUntilIdle(Characters.Mike));

            yield return new WaitForSeconds(3);


            mikeController.State = MikeState.GoPickUp;
            //meganController.State = MeganState.GoPickUp;
            //jayController.State = JayState.GoPickUp;

            #endregion









            /*  switch  (optionscontroler.option)
              {



                  default:
              }*/
        }
    }




    #region WaitFotStateMethods
    IEnumerator WaitUntilWalking(Characters character)
    {
        if (character == Characters.Remy)
        {
            yield return new WaitUntil(() => remyController.State == RemyState.Walking);
        }
        else if (character == Characters.Mike)
        {
            yield return new WaitUntil(() => mikeController.State == MikeState.Walking);
        }
        else if (character == Characters.Megan)
        {
            yield return new WaitUntil(() => meganController.State == MeganState.Walking);

        }
        else if (character == Characters.Jay)
        {
            yield return new WaitUntil(() => jayController.State == JayState.Walking);
        }

    }

    IEnumerator WaitUntilTalking(Characters character)
    {
        if (character == Characters.Remy)
        {
            yield return new WaitUntil(() => remyController.State == RemyState.Talking);
        }

    }

    IEnumerator WaitUntilStanding(Characters character)
    {
        if (character == Characters.Remy)
        {
            yield return new WaitUntil(() => remyController.State == RemyState.Standing);
        }
        else if (character == Characters.Mike)
        {
            yield return new WaitUntil(() => mikeController.State == MikeState.Standing);
        }
        else if (character == Characters.Megan)
        {
            yield return new WaitUntil(() => meganController.State == MeganState.Standing);

        }
        else if (character == Characters.Jay)
        {
            yield return new WaitUntil(() => jayController.State == JayState.Standing);
        }
    }
    IEnumerator WaitUntilSitting(Characters character)
    {
        if (character == Characters.Remy)
        {
            yield return new WaitUntil(() => remyController.State == RemyState.Sitting);
        }
        else if (character == Characters.Mike)
        {
            yield return new WaitUntil(() => mikeController.State == MikeState.Sitting);
        }
        else if (character == Characters.Megan)
        {
            yield return new WaitUntil(() => meganController.State == MeganState.Sitting);

        }
        else if (character == Characters.Jay)
        {
            yield return new WaitUntil(() => jayController.State == JayState.Sitting);

        }
    }

    IEnumerator WaitUntilIdle(Characters character)
    {
        if (character == Characters.Remy)
        {
            yield return new WaitUntil(() => remyController.State == RemyState.Idle);
        }
        else if (character == Characters.Mike)
        {
            yield return new WaitUntil(() => mikeController.State == MikeState.Idle);
        }
        else if (character == Characters.Megan)
        {
            yield return new WaitUntil(() => meganController.State == MeganState.Idle);

        }
        else if (character == Characters.Jay)
        {
            yield return new WaitUntil(() => jayController.State == JayState.Idle);

        }
    }

    IEnumerator WaitUntilWaving(Characters character)
    {
        if (character == Characters.Remy)
        {
            yield return new WaitUntil(() => remyController.State == RemyState.Waving);
        }
        else if (character == Characters.Mike)
        {
            yield return new WaitUntil(() => mikeController.State == MikeState.Waving);
        }
        else if (character == Characters.Megan)
        {
            yield return new WaitUntil(() => meganController.State == MeganState.Waving);

        }
        else if (character == Characters.Jay)
        {
            yield return new WaitUntil(() => jayController.State == JayState.Waving);

        }
    }

    #endregion
    /*  IEnumerator WaitForOption()
      {
          yield return new WaitUntil(() => option.option != null);
      }*/
}
