using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Helper class that every class file extends. Gives access
 * to the whole application.</summary>
 * 
 */
public class Element : MonoBehaviour
{

    public GauntletApp app { get { return GauntletApp.Instance; } }

}

/**
 * <summary>The main entry point of the application. Holds references
 * to the data, the controllers, and the views.</summary>
 * 
 */
public class GauntletApp : MonoBehaviour
{
    public static GauntletApp Instance;

    public GauntletData data;
    public GauntletController controller;
    public GauntletView view;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        if (data == null) data = FindObjectOfType<GauntletData>();

        if (controller == null) controller = FindObjectOfType<GauntletController>();

        if (view == null) view = FindObjectOfType<GauntletView>();
    }
}
