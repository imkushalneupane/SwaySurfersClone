using UnityEngine;

public class CameraLookAtPlayer : MonoBehaviour
{
    public Transform player;       // Player to look at
    public float rotationSpeed = 5f; // Rotation smoothness

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
