using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called one per frame
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

    //Resume
    //Upon pressing the button, it will resume the given time scale and closes the Pause Menu.
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        //Normal time scale
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //Pause
    //Pressing the escape key brings up the Pause Menu witht he corresponding buttons and pauses the Scene in the background.
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
