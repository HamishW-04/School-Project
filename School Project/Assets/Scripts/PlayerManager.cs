using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    //Attributes
    private int colonistsNum;
    private int maxColonists;
    private float[] currency = new float[3];

    //Components
    private GUIManager gui;
    private PlayerInput input;
    private Rigidbody rb;

    private void Start()
    {
        gui = GameObject.FindWithTag("GameController").GetComponent<GUIManager>();
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        int swapInput = -input.swapTarget;
        if (swapInput != 0) gui.ChangeTarget(swapInput);

        gui.UpdateSpeedGUI(new Vector2(transform.position.x, transform.position.z), new Vector2(rb.velocity.x, rb.velocity.z));
    }
}
