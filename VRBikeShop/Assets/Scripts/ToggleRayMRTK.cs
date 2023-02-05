using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRayMRTK : MonoBehaviour
{
    [Tooltip("Defines the Offset angle, to correct the Ray error from MRTK3")]
    [Range(-180.0f, 180.0f)]
    public float OffsetAngle = 149f;
    //public Transform TestCube;
    private Transform TeleportRay;
    private Transform UIRay;
    private Transform RayHitMarker;
    enum Mode { Off, UI, Teleport}
    private Mode state = Mode.Off;
    private bool changeHappened = false;

    // Start is called before the first frame update
    void Start()
    {
        TeleportRay = transform.Find("Far Ray (Teleport)");
        UIRay = transform.Find("Far Ray (UI)");
        Debug.Log("ToggleRayMRTK");
        RayHitMarker = TeleportRay.Find("RayReticle");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Direction = Vector3.Normalize(RayHitMarker.position - this.transform.position);
        var ray = new Ray(this.transform.position+ Direction*0.2f, Direction );
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Default"); 

        if (Physics.Raycast(ray, out hit, 10, mask))
        {
            //Debug.Log(state.ToString());
            //TestCube.position = RayHitMarker.position;
            if (hit.transform.gameObject.tag == "UI_RayInteractable" && state != Mode.UI)
            {
                state = Mode.UI;
                changeHappened = true;
                Debug.Log("ToggleRayMRTK - Switched to UI Ray");
            }
            
            else if (hit.transform.gameObject.tag == "Teleport" && state != Mode.Teleport)
            {
                state = Mode.Teleport;
                changeHappened = true;
                Debug.Log("ToggleRayMRTK - Switched to Teleport Ray");
            }

            else if (hit.transform.gameObject.tag == "Untagged" && state != Mode.Off)
            {
                state = Mode.Off;
                changeHappened = true;
                Debug.Log("ToggleRayMRTK - Switched Ray Off");
            }
        }
        else if (state != Mode.Off)
        {
            state = Mode.Off;
            changeHappened = true;
            Debug.Log("ToggleRayMRTK - Switched Ray Off");
        }

        if (changeHappened)
        {
            changeHappened = false;
            SwitchRays(state);
        }

    }

    void SwitchRays(Mode state)
    {
        switch (state)
        {
            case Mode.Off:
                TeleportRay.gameObject.SetActive(false);
                UIRay.gameObject.SetActive(false);
                break;
            case Mode.UI:
                TeleportRay.gameObject.SetActive(false);
                UIRay.gameObject.SetActive(true);
                break;
            case Mode.Teleport:
                TeleportRay.gameObject.SetActive(true);
                UIRay.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
