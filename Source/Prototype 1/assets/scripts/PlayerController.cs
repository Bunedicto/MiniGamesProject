using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private variables
    // [SerializeField] float speed = 5.0f;
    [SerializeField] private float horsePower = 0.0f;
    [SerializeField] float turnSpeed = 10.0f;
    [SerializeField] float directionalInput;
    [SerializeField] float forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Player input
        directionalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the vehicle forward
        //transform.Translate(Vector3.forward * Time.deltaTime * forwardInput * speed);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
        //transform.Translate(Vector3.right * Time.deltaTime * directionalInput * turnSpeed);

        // Change vehicle direction
        transform.Rotate(Vector3.up * Time.deltaTime * directionalInput * turnSpeed);
    }
}
