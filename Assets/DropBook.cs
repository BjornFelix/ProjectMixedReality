using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBook : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Book")
        {

            Debug.Log("Dropping Book");
            var someTransform = other.gameObject.transform;
            someTransform.parent = this.transform;
            someTransform.localPosition = Vector3.zero;
            someTransform.localRotation = Quaternion.Euler(0f, 125f, 90f);
            someTransform.localScale = new Vector3(0.4615385f, 1f, 1f);
        }
    }
}
