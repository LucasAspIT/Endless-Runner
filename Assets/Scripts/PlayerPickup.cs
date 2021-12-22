using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField]
    GameObject ps;

    [SerializeField]
    GameObject floatingTextPrefab;

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
            if (floatingTextPrefab != null)
            {
            ShowFloatingText();
            }
        }
    }

    private void ShowFloatingText()
    {
        Instantiate(floatingTextPrefab, transform.position, Quaternion.Euler(45f, 45f, 0f));
    }
}
