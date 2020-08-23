using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /**
     * <summary>Loads the next scene of the game.</summary>
     */
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("PLaying game...");
    }

    /**
     * <summary>Opens a link to a Google Forms page for feedback purposes.</summary>
     */
    public void OpenForms ()
    {
        Application.OpenURL("https://forms.gle/jXxePT7SYMCxcXQ49");
    }

    /**
     * <summary>Closes the application.</summary>
     */
    public void QuitGame ()
    {
        Application.Quit();
    }
}
