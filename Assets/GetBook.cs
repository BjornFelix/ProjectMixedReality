using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBook : MonoBehaviour
{
    public GameObject book;
    public GameObject playerHand;
    public void getBook()
    {


        var someBone = playerHand.transform;
        Debug.Log("pickup book");

        var someTransform = book.transform;
        someTransform.parent = someBone;
        someTransform.localPosition = Vector3.zero;
        someTransform.localRotation = Quaternion.Euler(-10f, 70f, 20f);
        someTransform.localScale = new Vector3(0.4f, 0.5f, 0.5f);



    }
}
