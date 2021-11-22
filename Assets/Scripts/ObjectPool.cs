using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Start()
    {

    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
