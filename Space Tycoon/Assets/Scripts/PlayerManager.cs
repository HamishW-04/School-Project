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

    [Header("Colony/Landed")]
    public bool landed;

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

    private void OnCollisionEnter(Collision collision)
    {
        //Check if we are on a planet
    }
}

public struct PlanetCheck
{
    public GameObject checkObj;
    public Planet planet;
    public bool isPlanet;

    public PlanetCheck(GameObject checkObj, Planet planet , bool isPlanet)
    {
        this.checkObj = checkObj;
        this.planet = planet;
        this.isPlanet = isPlanet;
    }

    public static PlanetCheck IsPlanet(GameObject obj)
    {
        if (obj.tag == "Gravity Body" && obj.TryGetComponent<Planet>(out Planet p))
        {
            return new PlanetCheck(obj, p,true);
        }
        else
        {
            return new PlanetCheck(obj, null ,false);
        }
    }
}