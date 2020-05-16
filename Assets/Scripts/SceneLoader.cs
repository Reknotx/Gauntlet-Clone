using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* Author: Donato, Justin
* Date: 04/10/2019
* Loads the desired scene
*/
public class SceneLoader : MonoBehaviour {

    public string levelToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
