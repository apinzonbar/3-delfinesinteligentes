using UnityEngine;

// This script handles the coin pickup behavior, spinning animation, and audio feedback.
public class CoinItem : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 100f; // Speed at which the coin spins in place

    [Header("Audio Settings")]
    public AudioClip pickupSound; // Drag your coin sound effect (SFX) here

    void Update()
    {
        // Visual polish: Makes the coin rotate automatically every frame
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object passing through the coin is tagged as the Player
        if (other.CompareTag("Player"))
        {
            // Find the PlayerController script attached to Bob
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.AddCoin(); // Call Bob's script to add 1 to the counter

                // Play the pickup sound effect in 3D space at the coin's position
                if (pickupSound != null)
                {
                    AudioSource.PlayClipAtPoint(pickupSound, transform.position);
                }

                // Destroy this coin so it disappears from the map
                Destroy(gameObject);
            }
        }
    }
}