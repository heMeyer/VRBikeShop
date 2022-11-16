using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Toggle between the direct and ray interactor if the direct interactor isn't touching any objects
/// Should be placed on a ray interactor
/// </summary>
[RequireComponent(typeof(XRRayInteractor))]
public class ToggleRay : MonoBehaviour
{

    private XRRayInteractor rayInteractor = null;
    private XRInteractorLineVisual lineVisual = null;
    private bool isSwitched = true;
    private bool RaycastOverride = false;

    private void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        lineVisual = GetComponentInChildren<XRInteractorLineVisual>();

        SwitchInteractors(false);
    }
    private void Update()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.gameObject);

            if (hit.transform.gameObject.tag == "UI_RayInteractable" && !isSwitched)    //Ray darf nur angeschaltet werden wenn nicht eh schon an
            {
                SwitchInteractors(true);
            } 
            else if (!(hit.transform.gameObject.tag == "UI_RayInteractable") && !RaycastOverride && isSwitched)                                    //Ray darf nur ausgeschaltet werden wenn nicht durch Steuerknüppel angeschaltet und nicht eh schon aus
            {
                SwitchInteractors(false);
            }
        }
    }

    public void ToggleRayCast()
    {
        if (isSwitched)
        {
            SwitchInteractors(false);
        }
        else
        {
            SwitchInteractors(true);
        }
    }

    public void RayCastOn()
    {
        SwitchInteractors(true);
        RaycastOverride = true;
    }

    public void RayCastOff()
    {
        SwitchInteractors(false);
        RaycastOverride = false;
    }

    private void SwitchInteractors(bool value)
    {
        isSwitched = value;
        lineVisual.enabled = value;
    }
}
