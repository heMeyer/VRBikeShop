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
        int layerDefault = 1 << 0;
        //int layerMaskUI = 1 << 5;
        //int layerMaskObstacle = 1 << 2;

        if(Physics.Raycast(ray, out hit, 10, layerDefault))
        {
            // Debug.Log(hit.transform.gameObject);
            //Ray darf nur angeschaltet werden wenn UI... getroffen wird und nicht eh schon an
            if (hit.transform.gameObject.tag == "UI_RayInteractable" && !isSwitched)
            {
                SwitchInteractors(true);
            }
            //Ray darf nur ausgeschaltet werden wenn nicht durch Steuerknüppel angeschaltet, kein UR... getroffen wird und nicht eh schon aus
            else if (!(hit.transform.gameObject.tag == "UI_RayInteractable") && !RaycastOverride && isSwitched)
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
