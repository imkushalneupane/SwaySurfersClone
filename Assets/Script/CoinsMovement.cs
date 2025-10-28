using UnityEngine;

public class CoinsMovement: MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private float bobAmplitude = 0.25f;
    [SerializeField] private float bobFrequency = 2f;

    private Vector3 startPos;
    private float timeOffset;

    void Start()
    {
        startPos = transform.position;
        // give each coin a random offset so they don't animate in sync
        timeOffset = Random.Range(0f, 2 * Mathf.PI);
    }

    void Update()
    {
        // Rotation (same speed, just rotates)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

        // Bobbing with time offset to desync them
        float newY = startPos.y + Mathf.Sin(Time.time * bobFrequency + timeOffset) * bobAmplitude;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
