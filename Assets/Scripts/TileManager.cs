using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    GameObject tilePrefab;

    [SerializeField]
    public GameObject currentTile;

    // Singleton
    private static TileManager instance;

    public static TileManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TileManager>(); // Make a reference to the TileManager instance so it can be accessed from other places.
            }
            return instance;
        }
    }

    void Start()
    {
        // Spawn some initial tiles.
        for (int i = 0; i < 30; i++)
        {
            SpawnTile();
        }
    }

    /// <summary>
    /// Spawn the next tile, and set it as the currentTile.
    /// </summary>
    public void SpawnTile()
    {
        int newTilePosX;
        int newTilePosZ;

            // 50/50 chance to spawn in either two directions.
            if (Random.value < 0.5f)
            {
                newTilePosX = 2;
                newTilePosZ = 0;
            }
            else
            {
                newTilePosX = 0;
                newTilePosZ = 2;
            }

            GameObject spawnedTile = ObjectPool01.SharedInstance.GetPooledObject(); // Take a GameObject from the pool.

            if (spawnedTile != null)
            {
                // Position and activate the object.
                spawnedTile.transform.position = new Vector3(currentTile.transform.position.x + newTilePosX, currentTile.transform.position.y, currentTile.transform.position.z + newTilePosZ);
                spawnedTile.transform.rotation = Quaternion.identity;
                currentTile = spawnedTile;
                spawnedTile.SetActive(true);
            }
    }
}
