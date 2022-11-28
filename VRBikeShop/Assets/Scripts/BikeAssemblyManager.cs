using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BikeAssemblyManager : MonoBehaviour
{
    XRSocketInteractor xRSocketInteractor;
    private bool somethingInSocket = false;
    public int partCount = 0;
    public GameObject bicycleAssembly;

    // Start is called before the first frame update
    void Start()
    {
        xRSocketInteractor = GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        socketCheck();
        if (somethingInSocket && partCount >= 13)
        {
            mergeBike();
        }
    }

    void socketCheck()
    {
        somethingInSocket = xRSocketInteractor.hasSelection;
    }

    public void addInSocket()
    {
        partCount++;
    }

    void mergeBike()
    {
            Debug.Log("Rad zusammengebaut");
    }
}
