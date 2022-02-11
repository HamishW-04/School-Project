using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    //Components
    private Rigidbody rb;
    public Transform orbitOrientation;

    //Attributs
    public Vector3 orbitTarget;
    private float orbitRadius;
    public float orbitSpeed;
    public float orbitForce;

    private void Start()
    {
        //Init components
        rb = GetComponent<Rigidbody>();
        orbitRadius = Vector3.Distance(orbitTarget, transform.position);

        //Init Velocity
        rb.velocity = Vector3.right * orbitSpeed;
    }

    
    private void FixedUpdate()
    {
        //Point the orientation at the orbit point
        orbitOrientation.LookAt(orbitTarget);

        //Gravity - Inwards force
        Vector3 dir = (orbitTarget - transform.position).normalized; // Gets the ddirection
        float dist = Vector3.Distance(orbitTarget, transform.position); // gets the distance
        dist -= orbitRadius; // Keeps the diffrence between the desired distance and the actual distance
        float mag = dist* orbitForce; // Calculates a magnitude based on the distance and the return effect
        rb.AddForce(dir * mag);

        Debug.Log(dist);
    }
}
