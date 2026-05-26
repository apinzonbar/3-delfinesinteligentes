using UnityEngine;
using TMPro; // Required to control the TextMeshPro component

// This script controls the automatic movement of the water hazard
// and detects collision with the player to end the game.
public class WaterHazardController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float scrollSpeed = 3.0f; // Speed at which the water chases Bob

    [Header("UI & Sound Settings")]
    public GameObject gameOverText;   // Reference to the Game Over UI object
    public AudioSource gameOverSound; // Reference to the Audio Source component

    void Update()
    {
        // STEP 2 REQUIREMENT: Machine Mechanics (Constant movement)
        // Moves the hazard forward along the Z axis
        transform.Translate(Vector3.forward * scrollSpeed * Time.deltaTime);
    }

    // STEP 2 REQUIREMENT: Triggers
    private void OnTriggerEnter(Collider other)
    {
        // Detects if Bob (tagged as Player) touches the water
        if (other.CompareTag("Player"))
        {
            Debug.Log("GAME OVER: Bob fell into the water!");

            // STEP 2 REQUIREMENT: UI Update
            // This acts like checking the box in the Inspector automatically
            if (gameOverText != null)
            {
                gameOverText.SetActive(true); // Makes the Game Over text visible
            }

            // STEP 2 REQUIREMENT: Audio Effects
            // Plays the splash or game over sound clip
            if (gameOverSound != null)
            {
                gameOverSound.Play();
            }

            // Logic to stop the game
            Time.timeScale = 0; // This pauses the game execution
        }
    }
}