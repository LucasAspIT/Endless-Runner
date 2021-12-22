using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField]
    private float destroyTime = 1f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
