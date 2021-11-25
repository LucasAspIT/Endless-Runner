using System.Collections;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    [SerializeField]
    float fallDelay = 2f;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            TileManager.Instance.SpawnTile();
            PickupManager.Instance.SpawnPickup();
            StartCoroutine(FallDown());
        }
    }

    // OPTIMISE? #############################################################################################################
    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(fallDelay);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;

        yield return new WaitForSeconds(1f);
        rb.isKinematic = true;
        gameObject.SetActive(false);
    }
}
