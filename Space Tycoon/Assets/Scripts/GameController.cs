using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool paused;
    private GUIManager gui;

    private void Start()
    {
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        gui = GetComponent<GUIManager>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused) PauseGame();
            else UnPauseGame();
        }
    }

    private void PauseGame()
    {
        paused = true;

        //Pause simulation
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //Open GUI
        gui.PauseMenu(paused);

    }

    private void UnPauseGame()
    {
        paused = false;
        //Close GUI
        gui.PauseMenu(paused);

        //Unpause simulation
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
}
