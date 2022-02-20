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
        if (paused) return;

        paused = true;

        //Pause simulation
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //Open GUI
        gui.PauseMenu(paused);

    }

    public void UnPauseGame()
    {
        if (!paused) return;

        paused = false;
        //Close GUI
        gui.PauseMenu(paused);

        //Unpause simulation
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void SaveGame()
    {
        //Add save code here
        Debug.Log("Save button pressed!");
    }

    public void QuitGame()
    {
        Debug.Log("Quit button pressed!");
        Application.Quit();
    }
}
