using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadedData : MonoBehaviour
{
    private int highscore;

    public int Highscore
    {
        get
        {
            return highscore;
        }
        set
        {
            highscore = value;
        }
    }

    // Singleton
    private static LoadedData instance;
    public static LoadedData Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// <summary>
    /// Use the loaded database highscore and set it locally, if it's higher than what's saved locally.
    /// </summary>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log("Scene loaded fully.");
    }
}
