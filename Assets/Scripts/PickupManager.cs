using UnityEngine;

public class PickupManager : MonoBehaviour
{
    [SerializeField]
    GameObject pickupPrefab;

    [SerializeField]
    [Range(0, 1)]
    private float pickupSpawnChance;

    // Singleton
    private static PickupManager instance;

    public static PickupManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PickupManager>(); // Make a reference to the PickupManager instance so it can be accessed from other places.
            }
            return instance;
        }
    }

    /// <summary>
    /// Spawn a pickup.
    /// </summary>
    public void SpawnPickup()
    {
        if (Random.value < pickupSpawnChance)
        {
            GameObject spawnedPickup = ObjectPool02.SharedInstance.GetPooledObject(); // Take a GameObject from the pool.

            if (spawnedPickup != null)
            {
                // Position and activate the object.
                spawnedPickup.transform.position = new Vector3(TileManager.Instance.currentTile.transform.position.x - 0.3f, TileManager.Instance.currentTile.transform.position.y + 2.6f, TileManager.Instance.currentTile.transform.position.z - 0.2f);
                spawnedPickup.transform.rotation = Quaternion.identity;
                spawnedPickup.SetActive(true);
            }
        }
    }
}
