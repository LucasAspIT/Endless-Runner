using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreAndGameover : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    public TextMeshProUGUI scoreTextHUD;

    private static ScoreAndGameover instance;

    public static ScoreAndGameover Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<ScoreAndGameover>(); // Make a reference to the ScoreAndGameover instance so it can be accessed from other places
            }
            return instance;
        }
    }


    private int points;

    public int Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
            scoreTextHUD.text = "SCORE: " + Points.ToString();
            // Debug.Log("Points property 'set' activated.");
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Reloads the scene, effectively "restarting" the game.
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
