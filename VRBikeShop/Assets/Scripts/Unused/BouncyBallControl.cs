using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBallControl : MonoBehaviour
{
    public float force = 1000f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxis("Horizontal") * Time.deltaTime * force;
        float movementY = Input.GetAxis("Vertical") * Time.deltaTime * force;
        float movementZ = Input.GetAxis("UpAndDown") * Time.deltaTime * force;
        Vector3 movement3 = new Vector3(movementX, movementY, movementZ);
        rb.AddForce(movement3);
    }
}
