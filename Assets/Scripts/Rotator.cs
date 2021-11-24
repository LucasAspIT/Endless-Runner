using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float minSpeed, maxSpeed;
    float randomX, randomY, randomZ;

    private void Start()
    {
        randomX = UnityEngine.Random.Range(minSpeed, maxSpeed);
        randomY = UnityEngine.Random.Range(minSpeed, maxSpeed);
        randomZ = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(randomX, randomY, randomZ) * Time.deltaTime);
    }
}
