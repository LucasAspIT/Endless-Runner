using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 10f)]
    float speed = 5f;

    private Rigidbody rb;
    private bool xy = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Mouse 0");

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





        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
}
