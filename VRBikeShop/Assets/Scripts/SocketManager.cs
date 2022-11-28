using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketManager : MonoBehaviour
{
    XRSocketInteractor xrSocketInteractor;
    BikeAssemblyManager bikeAssemblyManager;
    private bool somethingInSocket = false;
    private bool alreadySent = false;

    // Start is called before the first frame update
    void Start()
    {
        xrSocketInteractor = GetComponent<XRSocketInteractor>();
        bikeAssemblyManager = GameObject.Find("Socket_Bike").GetComponent<BikeAssemblyManager>();
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

            if(!alreadySent)
            {
                bikeAssemblyManager.addInSocket();
            }
        }
    }
}
