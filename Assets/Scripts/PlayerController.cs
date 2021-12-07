using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject player;


    [SerializeField]
    [Range(1f, 10f)]
    private float speed = 5f;

    [SerializeField]
    GameObject highscoreText;

    [SerializeField]
    GameObject restartButton;

    private Rigidbody rb;
    private bool xy = true;
    private bool deathComplete = false;

    public static bool isDead;
    public static bool isEnabled = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isDead = false;

        // Make sure the game isn't paused on start
        Time.timeScale = 1;
    }

    void Update()
    {
        // Click/tap control - make sure player isn't dead, that controls are enabled, and what's being clicked/tapped is a gameobject (not UI).
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isDead && isEnabled && !EventSystem.current.IsPointerOverGameObject())
        {
            ScoreAndGameover.Instance.Points++;

            // Switch between moving the two directions.
            if (xy)
            {
                rb.velocity = new Vector3(speed, 0f, 0f);
                xy = false;
            }
            else
            {
                rb.velocity = new Vector3(0f, 0f, speed);
                xy = true;
            }
        }

        // Player death.
        if (!isDead && player.transform.position.y < 0)
        {
            isDead = true;
        }

        if (isDead && !deathComplete)
        {
            // Enable death screen.
            if (player.transform.position.y < -10)
            {
                ScoreAndGameover.Instance.DeathScore();
                highscoreText.SetActive(true);
                restartButton.SetActive(true);
            }

            // Stop player from falling forever after death.
            if (player.transform.position.y < -20)
            {
                Time.timeScale = 0;
                deathComplete = true;
            }
        }
    }
}
