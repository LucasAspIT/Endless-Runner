using System.Collections.Generic;
using UnityEngine;

public class ObjectPool02 : MonoBehaviour
{
    public static ObjectPool02 SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;

        pooledObjects = new List<GameObject>(); // List to hold all the instantiated objects
        GameObject temp; // Temporarily used to ready each object in the for loop

        // Ready the specified amount of objects in a disabled state
        for (int i = 0; i < amountToPool; i++)
        {
            temp = Instantiate(objectToPool); // Instantiate the object
            temp.SetActive(false); // Disable the object
            pooledObjects.Add(temp); // Add the object to the pooledObjects list
        }
    }

    /// <summary>
    /// Returns a GameObject from the object pool, in a deactivated state.
    /// </summary>
    /// <returns>A pooled object, ready to be activated and used. Otherwise returns null, if no pooled object is deactivated and in the pool.</returns>
    public GameObject GetPooledObject()
    {
        // Goes through the pooledObjects List of GameObjects until it finds a deactivated one then returns it.
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        // If the for loop finds nothing, return null.
        return null;
    }
}
