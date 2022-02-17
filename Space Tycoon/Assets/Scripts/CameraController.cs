using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Attributes
    public Transform camTarget;
    public float sens;
    public float minX, maxX;
    private float xRot;

    //Components
    private PlayerInput input;

    private void Start()
    {
        //Initialize
        input = GetComponent<PlayerInput>();
        xRot = 30;
    }

    private void Update()
    {
        //Orbit Vertically
        float vInput = input.MouseInput.y * sens * Time.deltaTime;
        xRot -= vInput;
        xRot = Mathf.Clamp(xRot, minX, maxX);
        camTarget.localRotation = Quaternion.Euler(xRot, camTarget.localRotation.eulerAngles.y, 0f);

        //Orbit Horizontally
        float hInput = input.MouseInput.x * sens * Time.deltaTime;
        camTarget.Rotate(Vector3.up * hInput);

        //Position camera
        camTarget.position = transform.position;
    }
}
