using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Attributes
    public float thrustMagnitude;
    public float torqueMagnitude;
    public float thrustRatio;
    private bool canMove;

    public float FuelCounter { get => fuelCounter;}
    private float fuelCounter;
    private float fuelEfficiency;

    //Components
    private PlayerInput playerInput;
    private PlayerManager manager;
    private UniverseController universe;
    private Rigidbody rb;

    private void Start()
    {
        //Initialize components
        playerInput = GetComponent<PlayerInput>();
        manager = GetComponent<PlayerManager>();
        universe = GameObject.FindGameObjectWithTag("GameController").GetComponent<UniverseController>();
        rb = GetComponent<Rigidbody>();

        fuelEfficiency = 0.01f;
        fuelCounter = manager.MaxFuel;
        canMove = true;
    }

    private void FixedUpdate()
    {
        //Move
        if (canMove) AddThrust(playerInput.MoveInput);
        AddRotationalForce(playerInput.RoatateInput);
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        Vector3 gravForce = universe.GetResultantGrav(transform.position);
        rb.AddForce(gravForce);
    }

    private void AddThrust(Vector2 movementInput)
    {
        Vector3 force = Vector3.zero;

        //ApplyForward force
        if (movementInput.y > 0)
        {
            force += transform.forward.normalized;
        }
        else if (movementInput.y < 0)
        {
            force += -transform.forward.normalized * thrustRatio;
        }

        //SideWays
        force += transform.right * movementInput.x * thrustRatio;

        fuelCounter -= force.magnitude * fuelEfficiency;

        if (fuelCounter <= 0) canMove = false;

        rb.AddForce(force * thrustMagnitude);
    }

    private void AddRotationalForce(float turnInput)
    {
        rb.AddTorque(transform.up * turnInput * torqueMagnitude);
    }

    public void Refuel()
    {
        fuelCounter = manager.MaxFuel;
    }
}
