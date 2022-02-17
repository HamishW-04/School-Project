using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravBody : MonoBehaviour
{
    //Attributes
    public float mass;
    public Vector2 position2 { get { return new Vector2(transform.position.x, transform.position.z); } }
    public Vector3 position { get { return transform.position; } }
    public Rigidbody rb;

    public void Start()
    {
        //Initialize
        rb = GetComponent<Rigidbody>();
    }
}
