using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    //Attributes
    //Colonists and resources
    private int colonistsNum;
    private int maxColonists;
    private float[] currency = new float[3];

    //Ship
    public float MaxFuel { get => maxFuel; }
    [SerializeField] private float maxFuel;

    //Components
    private GUIManager gui;
    private PlayerInput input;
    private PlayerMovement movement;
    private Rigidbody rb;

    private void Start()
    {
        gui = GameObject.FindWithTag("GameController").GetComponent<GUIManager>();
        input = GetComponent<PlayerInput>();
        movement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();

        gui.UpdateSpeedGUI(new Vector2(transform.position.x, transform.position.z), new Vector2(rb.velocity.x, rb.velocity.z));
        gui.UpdateFuelGauge(maxFuel, movement.FuelCounter);
    }

    private void Update()
    {
        int swapInput = input.SwapTarget;
        if (swapInput != 0) gui.ChangeTarget(swapInput);

        gui.UpdateSpeedGUI(new Vector2(transform.position.x, transform.position.z), new Vector2(rb.velocity.x, rb.velocity.z));
        gui.UpdateFuelGauge(maxFuel, movement.FuelCounter);
    }

    public void Refuel()
    {
        movement.Refuel();
    }
}
