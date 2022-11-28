using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBookFromBackPack : MonoBehaviour
{
    public GameObject book;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "StudentHand")
        {
            var someBone = other.gameObject.transform;
            Debug.Log("pickup book");

            var someTransform = book.transform;
            someTransform.parent = someBone;
            someTransform.localPosition = Vector3.zero;
            someTransform.localRotation = Quaternion.identity;
            someTransform.localScale = new Vector3(0.4f, 0.5f, 0.5f);
        }


    }
}
