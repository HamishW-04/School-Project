using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //Inputs
    public Vector2 moveInput;
    public Vector2 mouseInput;
    public int swapTarget; 

    private void Update()
    {
        //Get Inputs
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        swapTarget = AxisInput(KeyCode.C, KeyCode.X);
    }

    private int AxisInput(KeyCode pos, KeyCode neg)
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
}
