using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("In de rugzak");
    }
}