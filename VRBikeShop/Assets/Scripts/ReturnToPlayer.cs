using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPlayer : MonoBehaviour
{
    public float floorLevel = -1.0f;
    private Transform PlayerCamera;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCamera = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < floorLevel)
        {
            this.transform.position = PlayerCamera.position;
        }
    }
}
