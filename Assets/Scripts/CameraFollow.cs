using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target to follow (e.g., the player)
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement
    public Vector3 offset; // Offset from the target position

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            desiredPosition.x = 0;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            Vector3 lookatposition = target.position;
            lookatposition.z += 10;
            transform.LookAt(lookatposition); // Make the camera look at the target
        }
    }
}
