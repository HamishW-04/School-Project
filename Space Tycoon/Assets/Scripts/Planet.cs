using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : GravBody
{
    //Attribues
    [Header("Object Info")]
    public string planetName;
    

    [Header("Orbit")]
    public float orbitSpeed;
    public float orbitForce;
    private float orbitRadius;
    public Transform orbitOrientation;
    public Vector3 orbitTarget;

    

    new private void Start()
    {
        base.Start();

        orbitRadius = Vector3.Distance(position, orbitTarget);
    }

    private void FixedUpdate()
    {
        //Orbit
        OrbitVelocity();
    }

    private void OrbitVelocity()
    {
        if (rb == null) return;

        //Add force to keep momentum
        orbitOrientation.LookAt(orbitTarget);
        rb.velocity = orbitOrientation.right * orbitSpeed;

        //Gravity like force
        Vector3 dir = orbitTarget - position;
        float dist = Vector3.Distance(position, orbitTarget);
        dist -= orbitRadius;
        float mag = dist * orbitForce;
        
        rb.AddForce(dir * mag);
    }
}
