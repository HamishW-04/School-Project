using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //Inputs
    public Vector2 MoveInput { get => moveInput; }
    private Vector2 moveInput;
    public Vector2 MouseInput { get => mouseInput; }
    private Vector2 mouseInput;
    public float RoatateInput { get => rotateInput; }
    private float rotateInput;
    public int SwapTarget { get => swapTarget; }
    private int swapTarget;

    private void Update()
    {
        //Get Inputs
        moveInput = new Vector2(AxisInput(KeyCode.Q, KeyCode.E), Input.GetAxisRaw("Vertical"));
        rotateInput = Input.GetAxisRaw("Horizontal");
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        swapTarget = AxisInputDown(KeyCode.C, KeyCode.X);
    }

    private int AxisInputDown(KeyCode pos, KeyCode neg)
    {
        if (Input.GetKeyDown(pos))
        {
            return 1;
        }else if (Input.GetKeyDown(neg))
        {
            return -1;
        }else
        {
            return 0;
        }
    }

    private int AxisInput(KeyCode pos, KeyCode neg)
    {
        if (Input.GetKey(pos))
        {
            return 1;
        }
        else if (Input.GetKey(neg))
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}
