using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isDead = false;

        // Make sure the game isn't paused on start
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Click/tap control
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isDead)
        {
            // Debug.Log("Mouse 0");
            ScoreAndGameover.Instance.Points++;

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

        /*
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        */


        // Player death
        if (player.transform.position.y < 0)
        {
            isDead = true;
            Debug.Log("Player isDead = true.");
        }

        // Enable death screen
        if (player.transform.position.y < -10)
        {
            ScoreAndGameover.Instance.DeathScore();
            highscoreText.SetActive(true);
            restartButton.SetActive(true);
        }

        // Stop player from falling forever after death
        if (player.transform.position.y < -20)
        {
            Time.timeScale = 0;
            Debug.Log("Position Y: Less than 20, activated.");
        }
    }
}
