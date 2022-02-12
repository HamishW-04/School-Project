using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Attributes
    public float thrustMagnitude;
    public float torqueMagnitude;

    //Components
    private PlayerInput playerInput;
    private UniverseController universe;
    private Rigidbody rb;

    private void Start()
    {
        //Initialize components
        playerInput = GetComponent<PlayerInput>();
        universe = GameObject.FindGameObjectWithTag("GameController").GetComponent<UniverseController>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Move
        AddForwardForce(playerInput.moveInput.y);
        AddRotationalForce(playerInput.moveInput.x);
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        Vector3 gravForce = universe.GetResultantGrav(transform.position);
        rb.AddForce(gravForce);
    }

    private void AddForwardForce(float forwardInput)
    {
        rb.AddForce(transform.forward * forwardInput * thrustMagnitude);
    }

    private void AddRotationalForce(float turnInput)
    {
        rb.AddTorque(transform.up * turnInput * torqueMagnitude);
    }
}
