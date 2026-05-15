using UnityEngine;

// This script controls the automatic movement of the water hazard
// and detects collision with the player to end the game.
public class WaterHazardController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float scrollSpeed = 3.0f; // Speed at which the water chases Bob

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

            // Logic to stop the game (Step 2: UI Update)
            Time.timeScale = 0; // This pauses the game

            // Here you would trigger your Game Over UI
        }
    }
}
