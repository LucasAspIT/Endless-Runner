using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    [Range(1f, 10f)]
    float speed = 5f;

    [SerializeField]
    GameObject highscoreText;

    [SerializeField]
    GameObject restartButton;

    private Rigidbody rb;
    private bool xy = true;

    public static bool isDead;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isDead = false;

        // Make sure the game isn't paused on start
        Time.timeScale = 1;
    }

    void Update()
    {
        // Click/tap control
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isDead)
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
        if (player.transform.position.y < 0)
        {
            isDead = true;
        }

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
        }
    }
}
