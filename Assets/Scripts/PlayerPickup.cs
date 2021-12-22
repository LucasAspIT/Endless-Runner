using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField]
    GameObject ps;

    [SerializeField]
    PlayRandomSFX randomPickupSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            ScoreAndGameover.Instance.Points += 3;
            randomPickupSFX.RandomSFX();
            Instantiate(ps, transform.position, Quaternion.identity);
        }
    }
}
