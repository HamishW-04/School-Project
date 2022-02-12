using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseController : MonoBehaviour
{
    public GravBody[] bodies;

    public void Start()
    {
        //Get all planets
        GameObject[] objectsTemp = GameObject.FindGameObjectsWithTag("Gravity Body");
        bodies = new GravBody[objectsTemp.Length];
        for (int i = 0; i < objectsTemp.Length; i++)
        {
            bodies[i] = objectsTemp[i].GetComponent<GravBody>();
        }
    }

    public Vector3 GetResultantGrav(Vector3 playerPos)
    {
        Vector3 force = Vector3.zero;
        foreach (GravBody b in bodies)
        {
            force += CalculateGravForce(playerPos, b);
        }

        return force;
    }

    private Vector3 CalculateGravForce(Vector3 playerPos, GravBody body)
    {
        float dist = Vector3.Distance(body.position, playerPos);
        float mag = (Universe.gravConstant * body.mass * Universe.playerMass) / (dist * dist);
        Vector3 dir = (body.position - playerPos).normalized;

        return dir * mag;
    }
}
