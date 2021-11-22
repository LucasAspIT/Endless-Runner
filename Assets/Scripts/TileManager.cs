using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    GameObject tilePrefab;

    [SerializeField]
    GameObject currentTile;

    // Singleton
    private static TileManager instance;

    public static TileManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TileManager>(); // Make a reference to the TileManager instance so it can be accessed from other places
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Spawn the next tile, and set it as the currentTile
    /// </summary>
    public void SpawnTile()
    {
        int newTilePosX;
        int newTilePosZ;

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

            GameObject spawnedTile = ObjectPool.SharedInstance.GetPooledObject(); // ##### probably fucks up the spawn position?

            if (spawnedTile != null)
            {
                // currentTile.transform.position = new Vector3(currentTile.transform.position.x + newTilePosX, -0.45f, currentTile.transform.position.z + newTilePosZ);
                spawnedTile.transform.position = new Vector3(currentTile.transform.position.x + newTilePosX, -0.45f, currentTile.transform.position.z + newTilePosZ);
                spawnedTile.transform.rotation = Quaternion.identity;
                currentTile = spawnedTile;
                spawnedTile.SetActive(true);
            }

        // currentTile = Instantiate(tilePrefab, new Vector3(currentTile.transform.position.x + newTilePosX, -0.45f, currentTile.transform.position.z + newTilePosZ), Quaternion.identity);
    }
}
