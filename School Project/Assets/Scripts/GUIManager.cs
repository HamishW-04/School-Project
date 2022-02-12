using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    [Header("GUI")]
    public Text speed;
    public Text velocity;
    public Planet targetPlanet = null;
    public Text targetText;
    public Text relSpeed;
    public Text colonistsText;
    public Text[] currencyText = new Text[3];

    private int targetIndex = 0;
    private List<Planet> planets;

    private void Start()
    {
        //Init
        GravBody[] temp = GetComponent<UniverseController>().bodies;
        planets = new List<Planet>();
        planets.Add(null);
        for (int i = 0; i < temp.Length; i++)
        {
            if(temp[i] is Planet)
            {
                planets.Add((Planet)temp[i]);
            }
        }
    }

    public void ChangeTarget(int swapInput)
    {
        if (planets == null) return;

        if (targetIndex < planets.Count - 1 && swapInput == 1) targetIndex++;
        if (targetIndex > 0 && swapInput == -1) targetIndex--;

        targetPlanet = planets[targetIndex];

        if (targetPlanet == null)
        {
            targetText.text = "None";
            relSpeed.text = "N/A";
        }
        else targetText.text = planets[targetIndex].planetName;
    }

    public void UpdateSpeedGUI(Vector2 pos, Vector2 vel)
    {
        speed.text = Mathf.RoundToInt(vel.magnitude).ToString();
        velocity.text = vel.ToString();

        if (targetPlanet != null)
        {
            Vector2 planetVel = new Vector2(targetPlanet.rb.velocity.x, targetPlanet.rb.velocity.z);

            Vector2 velDiff = vel - planetVel;
            Vector2 dir = (targetPlanet.position2 - pos).normalized;

            relSpeed.text = Mathf.RoundToInt(Vector2.Dot(velDiff, dir)).ToString();
        }
    }
}
