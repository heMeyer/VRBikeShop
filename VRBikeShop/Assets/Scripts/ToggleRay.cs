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
    RaycastHit hit;

    private void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        lineVisual = GetComponentInChildren<XRInteractorLineVisual>();

        SwitchInteractors(false);
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
    }

    public void RayCastOff()
    {
        SwitchInteractors(false);
    }

    private void SwitchInteractors(bool value)
    {
        isSwitched = value;
        lineVisual.enabled = value;
    }
}
