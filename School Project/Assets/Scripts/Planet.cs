using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    //Attribues
    public string planetName;
    public float mass;
    public float orbitSpeed;
    public Vector2 position2 { get { return new Vector2(transform.position.x, transform.position.z); } }
    public Vector3 position { get { return transform.position; } }
    public Rigidbody rb;

    private void Start()
    {
        //Initialize
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Orbit
        OrbitVelocity();
    }

    private void OrbitVelocity()
    {
        if (rb == null) return;

        Vector3 dir = Vector3.Cross(Vector3.up, Vector3.zero - position).normalized;
        rb.velocity = dir * orbitSpeed;
    }
}
