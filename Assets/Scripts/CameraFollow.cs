using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset;

    void LateUpdate()
    {
        if (!PlayerController.isDead)
        {
        transform.position = target.position + offset;
        }
    }
}
