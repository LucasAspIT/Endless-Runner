using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Firebase.Database;

public class ScoreAndGameover : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject liveShopButton;

    [SerializeField]
    private GameObject deadShopButton;

    [SerializeField]
    private TextMeshProUGUI topLeftScoreHUD;

    [SerializeField]
    private TextMeshProUGUI endScreenScoreHUD;

    [SerializeField]
    private TextMeshProUGUI highscoreTextHUD;

    [SerializeField]
    private GameObject firebaseManager;
    private FirebaseManager fbInstance;

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

    private void Awake()
    {
        // firebaseManager = gameObject.GetComponent<FirebaseManager>(); // ###################### Not pointing to right instance?
        // fbInstance = firebaseManager.GetComponent<FirebaseManager>();
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
            topLeftScoreHUD.text = "SCORE: " + Points.ToString();
        }
    }

    /// <summary>
    /// Moves the score of the run upon death, so it's in the middle of the screen, right above the high-score.
    /// </summary>
    public void PlayerDeath()
    {
        topLeftScoreHUD.enabled = false;
        endScreenScoreHUD.text = Points.ToString();

        if (Points > highscore)
        {
            highscore = Points;
            highscoreTextHUD.text = highscore.ToString();
        }

        liveShopButton.SetActive(false);
        deadShopButton.SetActive(true);

        // fbInstance.UpdateDatabaseUponDeath(highscore, Points);
        FirebaseManager.Instance.UpdateDatabaseUponDeath(highscore, Points);
        }


    /// <summary>
    /// Reloads the scene, effectively "restarting" the game.
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
