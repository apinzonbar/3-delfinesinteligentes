using UnityEngine;

public class GoalPlatform : MonoBehaviour
{
    [Header("UI Reference")]
    [Tooltip("Drag your custom 'YOU WIN' Image or Victory Canvas panel here")]
    public GameObject victoryPanel;

    [Header("Audio Settings")]
    private AudioSource victoryAudio; // Reference to the local AudioSource

    private void Start()
    {
        // Automatically fetch the AudioSource component attached to this object
        victoryAudio = GetComponent<AudioSource>();
    }

    // Detects when Bob's collider steps on the platform surface
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            // Verify if the player has gathered the 3 required coins
            if (player.coinsCollected >= 3)
            {
                ExecuteVictory();
            }
            else
            {
                Debug.Log("Mission incomplete: Bob needs all 3 coins!");
            }
        }
    }

    private void ExecuteVictory()
    {
        // 1. Play the victory sound effect if available
        if (victoryAudio != null)
        {
            // This allows the sound to play even if Time.timeScale is 0
            victoryAudio.ignoreListenerPause = true;
            victoryAudio.Play();
        }

        // 2. Display the custom graphic "YOU WIN" screen or image
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }

        // 3. Freeze game physics and stop the water hazard
        Time.timeScale = 0f;
    }
}