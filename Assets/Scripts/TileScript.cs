using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    [SerializeField]
    float fallDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            // ScoreAndGameover.Instance.Points++;
            // Debug.Log(ScoreAndGameover.Instance.Points);
            TileManager.Instance.SpawnTile();
            PickupManager.Instance.SpawnPickup();
            StartCoroutine(FallDown());
        }
    }

    // OPTIMISE #############################################################################################################
    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(fallDelay);
        // GetComponent<Rigidbody>().isKinematic = false;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        yield return new WaitForSeconds(1f);
        rb.isKinematic = true;
        // gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.SetActive(false);
    }
}
