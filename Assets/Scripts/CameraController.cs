using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    Vector3 offsetCamera;
    void Start()
    {
        offsetCamera = transform.position - player.position;
    }

    void Update()
    {
        transform.position = player.position + offsetCamera;
    }
}
