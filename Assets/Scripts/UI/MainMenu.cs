using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Clicking Play moves onto next scene
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("PLaying game...");
    }

    public void OpenForms ()
    {
        Application.OpenURL("https://forms.gle/jXxePT7SYMCxcXQ49");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
