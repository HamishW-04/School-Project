using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseController : MonoBehaviour
{
    public Planet[] planets;

    public void Start()
    {
        //Get all planets
        GameObject[] planetsTemp = GameObject.FindGameObjectsWithTag("Planet");
        planets = new Planet[planetsTemp.Length];
        for (int i = 0; i < planetsTemp.Length; i++)
        {
            planets[i] = planetsTemp[i].GetComponent<Planet>();
        }
    }

    public Vector3 GetResultantGrav(Vector3 playerPos)
    {
        Vector3 force = Vector3.zero;
        foreach (Planet p in planets)
        {
            force += CalculateGravForce(playerPos, p);
        }

        return force;
    }

    private Vector3 CalculateGravForce(Vector3 playerPos, Planet planet)
    {
        float dist = Vector3.Distance(planet.position, playerPos);
        float mag = (Universe.gravConstant * planet.mass * Universe.playerMass) / (dist * dist);
        Vector3 dir = (planet.position - playerPos).normalized;

        return dir * mag;
    }
}
