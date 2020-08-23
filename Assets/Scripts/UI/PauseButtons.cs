using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Stopped();
            }
        }
    }

    /**
     * <summary>Closes the pause menu and resumes the game by setting the timeScale back to 1.</summary>
     */
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        //Normal time scale
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    /**
     * <summary>Pauses the game by setting the time </summary>
     */
    private void Stopped()
    {
        pauseMenuUI.SetActive(true);
        //Stops time scale
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //Restart
    //Clicking Restart resets the level back to it's original form.
    private void Restart()
    {
        //Stops time scale
        Time.timeScale = 0f;
        Scene scene = SceneManager.GetActiveScene();
    }
   

    //LoadMenu
    //This makes the scene transition to the Main Menu upon clicking the button.
    public void LoadMenu()
    {
        //Makes sure game isn't paused in the menu; typically don't think this matters with a static menu
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }


    //QuitGame
    //When the button is pressed, it closes the application.
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    
}
