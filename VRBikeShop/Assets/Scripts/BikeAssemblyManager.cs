using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BikeAssemblyManager : MonoBehaviour
{
    XRSocketInteractor xRSocketInteractor;
    public GameObject bicycleAssembly;
    private bool somethingInSocket = false;
    public int partCount = 0;
    private ArrayList bikeParts = new ArrayList();

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
            partCount = 0;
        }
    }

    void socketCheck()
    {
        somethingInSocket = xRSocketInteractor.hasSelection;
    }

    public void addInSocket(GameObject bikePart)
    {
        partCount++;
        bikeParts.Add(bikePart);
    }

    void mergeBike()
    {
        Debug.Log("Rad zusammengebaut");

        foreach(GameObject go in bikeParts) {
            Destroy(go);
            // bikeParts.Remove(go);
        }

        bicycleAssembly.SetActive(true);
    }
}
