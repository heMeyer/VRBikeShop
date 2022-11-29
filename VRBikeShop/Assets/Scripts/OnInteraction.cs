using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInteraction : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bike" || other.gameObject.tag == "GrabInteractable")
        {
            other.attachedRigidbody.isKinematic = false;
        }
        
    }
}
