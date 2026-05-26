using UnityEngine;

public class TikiObstacle : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 2f;       // How fast the Tiki moves up and down
    public float heightRange = 1.5f; // How high and low the Tiki goes from its start position

    private Vector3 startPosition;

    void Start()
    {
        // Store the original spawn location of the Tiki
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position using a Sine wave for fluid back-and-forth movement
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * heightRange;

        // Apply the updated position to the Tiki object while keeping X and Z intact
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
