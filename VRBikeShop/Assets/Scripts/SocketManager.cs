using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketManager : MonoBehaviour
{
    XRSocketInteractor xrSocketInteractor;
    private bool somethingInSocket = false;

    // Start is called before the first frame update
    void Start()
    {
        xrSocketInteractor = GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        socketCheck();
    }

    public void socketCheck()
    {
        somethingInSocket = xrSocketInteractor.hasSelection;

        if(somethingInSocket)
        {
            IXRSelectInteractable obj = xrSocketInteractor.GetOldestInteractableSelected();
            Rigidbody rigidbody = obj.transform.gameObject.GetComponent<Rigidbody>();
            rigidbody.isKinematic = true;
        }
    }
}
