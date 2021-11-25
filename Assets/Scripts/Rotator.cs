using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float minSpeed, maxSpeed;
    float randomX, randomY, randomZ;

    private void Start()
    {
        randomX = Random.Range(minSpeed, maxSpeed);
        randomY = Random.Range(minSpeed, maxSpeed);
        randomZ = Random.Range(minSpeed, maxSpeed);
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(randomX, randomY, randomZ) * Time.deltaTime);
    }
}
