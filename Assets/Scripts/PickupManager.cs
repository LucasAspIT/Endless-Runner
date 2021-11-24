using System.Collections;
using System.Collections.Generic;
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
                instance = GameObject.FindObjectOfType<PickupManager>(); // Make a reference to the PickupManager instance so it can be accessed from other places
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Spawn a pickup.
    /// </summary>
    public void SpawnPickup()
    {
        if (Random.value < pickupSpawnChance)
        {
            GameObject spawnedPickup = ObjectPool02.SharedInstance.GetPooledObject();

            if (spawnedPickup != null)
            {
                spawnedPickup.transform.position = new Vector3(TileManager.Instance.currentTile.transform.position.x - 0.3f, TileManager.Instance.currentTile.transform.position.y + 2.6f, TileManager.Instance.currentTile.transform.position.z - 0.2f);
                spawnedPickup.transform.rotation = Quaternion.identity;
                // currentTile = spawnedPickup;
                spawnedPickup.SetActive(true);
            }
        }
    }
}
