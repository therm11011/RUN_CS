using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;    // Reference to the player's Transform
    public float smoothing = 5f;  // Smoothing factor for smooth camera movement

    private Vector3 offset;      // Distance between camera and player

    void Start()
    {
        // Store the initial offset between the player and camera
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Follow the player's position smoothly, maintaining the offset
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
