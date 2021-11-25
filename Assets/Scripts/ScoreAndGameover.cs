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

    [SerializeField]
    private TextMeshProUGUI highscoreTextHUD;
    private int highscore;

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
            if (points > highscore)
            {
                highscore = points;
                highscoreTextHUD.text = highscore.ToString();
            }
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
    /// Moves the score of the run upon death, so it's in the middle of the screen, right above the high-score.
    /// </summary>
    public void DeathScore()
    {
        scoreTextHUD.text = "SCORE:\n" + Points.ToString();
        scoreTextHUD.alignment = TextAlignmentOptions.Center;
        scoreTextHUD.transform.position = new Vector3(scoreTextHUD.transform.position.x, 660f, 0f);
    }

    /// <summary>
    /// Reloads the scene, effectively "restarting" the game.
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
