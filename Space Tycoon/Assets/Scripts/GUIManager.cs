using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIManager : MonoBehaviour
{
    [Header("GUI")]
    //Speed
    public GameObject[] UIElements;

    public GameObject pauseElement;

    public TMP_Text speed;
    public TMP_Text velocity;
    public Planet targetPlanet = null;
    public TMP_Text targetText;
    public TMP_Text relSpeed;

    //Colonists
    public TMP_Text colonistsText;
    public TMP_Text[] currencyText = new TMP_Text[3];

    //Fuel
    public RectTransform fuelGauge;
    private float maxGaugeScale;


    //Planet targetting
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

        maxGaugeScale = fuelGauge.transform.localScale.x;
    }

    private void EnableAll()
    {
        foreach(GameObject e in UIElements)
        {
            e.SetActive(true);
        }
    }

    private void DisabableAll()
    {
        foreach (GameObject e in UIElements)
        {
            e.SetActive(false);
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

    public void UpdateFuelGauge(float maxFuel, float currentFuel)
    {
        float multiplyer = currentFuel / maxFuel;
        Vector3 scale = fuelGauge.transform.localScale;

        if (multiplyer > 1) scale.x = maxGaugeScale;
        else if (multiplyer < 0) scale.x = 0;
        else scale.x = maxGaugeScale * multiplyer;

        fuelGauge.transform.localScale = scale;
    }

    

    public void PauseMenu(bool paused)
    {
        if (paused)
        {
            DisabableAll(); // Disable GUI

            pauseElement.SetActive(true); // enable pause gui
        }
        else
        {
            EnableAll(); // Enable GUI

            pauseElement.SetActive(false); // Disable pause gui
        }
    }

}
