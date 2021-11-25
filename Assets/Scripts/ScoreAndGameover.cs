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

    private int points;
    private int highscore;

    private static ScoreAndGameover instance;

    public static ScoreAndGameover Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreAndGameover>(); // Make a reference to the ScoreAndGameover instance so it can be accessed from other places.
            }
            return instance;
        }
    }

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
        }
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
