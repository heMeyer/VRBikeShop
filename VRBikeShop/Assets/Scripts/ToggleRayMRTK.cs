using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRayMRTK : MonoBehaviour
{
    private Transform TeleportRay;
    private Transform UIRay;
    enum Mode { Off, UI, Teleport}
    private Mode state = Mode.Off;
    private bool changeHappened = false;

    // Start is called before the first frame update
    void Start()
    {
        TeleportRay = transform.Find("Far Ray (Teleport)");
        UIRay = transform.Find("Far Ray (UI)");
        Debug.Log("ToggleRayMRTK");
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(this.transform.position,  Quaternion.Euler(225f,0f,0f) * this.transform.up);
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("Default"); 

        if (Physics.Raycast(ray, out hit, 10, mask))
        {
             //Debug.Log(state.ToString());

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
