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
        Vector3 camPos = player.position + offsetCamera;
        camPos.x = 0;
        camPos.y = 5;
        transform.position = camPos;
    }
}
