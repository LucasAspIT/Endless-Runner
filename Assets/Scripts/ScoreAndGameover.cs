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
    private int dbHighscore;
    private static bool initialScoreLoad;

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
        dbHighscore = LoadedData.Instance.Highscore;

        if (!initialScoreLoad)
        {
            // If local HS is higher than DB HS, load local HS and save it to DB.
            if (PlayerPrefs.GetInt("Highscore", 0) > dbHighscore)
            {
                // Load the local highscore and save it, if there is none use 0 as default. Ignore if the local highscore is less than the one loaded from the database.
                Highscore = PlayerPrefs.GetInt("Highscore", 0);

                // If the local highscore is higher, save it in the database.
                FirebaseManager.Instance.UpdateDatabaseHighscoreOnLoad(ScoreAndGameover.Instance.Highscore);
            }
            // If DB HS is higher than local HS, load DB HS and save it locally.
            else if (dbHighscore > PlayerPrefs.GetInt("Highscore", 0))
            {
                PlayerPrefs.SetInt("Highscore", dbHighscore);
                Highscore = dbHighscore;
            }
            // If both DB HS and local HS are the same, load it.
            else if (dbHighscore == PlayerPrefs.GetInt("Highscore", 0))
            {
                Highscore = dbHighscore;
            }
            // Make sure this only loads on first game start.
            initialScoreLoad = true;
        }

        // Load the score every game restart. (Not the initial first game.)
        if (Highscore == 0)
        {
            Highscore = PlayerPrefs.GetInt("Highscore", 0);
        }

        // Set the text for when the death screen is shown.
        highscoreTextHUD.text = Highscore.ToString();
    }

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

    private void Start()
    {

    }

    /// <summary>
    /// Moves the score of the run upon death, so it's in the middle of the screen, right above the high-score.
    /// </summary>
    public void PlayerDeath()
    {
        topLeftScoreHUD.enabled = false;
        endScreenScoreHUD.text = Points.ToString();

        if (Points > Highscore)
        {
            // If the highscore was beat, save the new highscore.
            PlayerPrefs.SetInt("Highscore", Points);
            Highscore = Points;
        }
        highscoreTextHUD.text = Highscore.ToString();

        liveShopButton.SetActive(false);
        deadShopButton.SetActive(true);

        FirebaseManager.Instance.UpdateDatabaseUponDeath(Highscore, Points);
        }

    public void ResetPlayerprefHighscore()
    {
        PlayerPrefs.DeleteKey("Highscore");
    }


    /// <summary>
    /// Reloads the scene, effectively "restarting" the game.
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene("EndlessRunner");
    }
}
