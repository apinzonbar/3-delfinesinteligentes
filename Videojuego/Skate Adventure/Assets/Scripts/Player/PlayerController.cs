using System;
using UnityEngine;
using TMPro; // Required to control the TextMeshPro UI component

public class PlayerController : MonoBehaviour
{
    // Movement settings
    [Header("Movement Forces")]
    public float forwardImpulse = 5f; // Power of each Space press (Forward)
    public float jumpPower = 12f;    // Power of W press (Jump)
    public float strafeImpulse = 4f;  // Power of A/D press (Sideways)

    [Header("Ground Check Settings")]
    public float groundDistance = 0.6f; // Length of the raycast to check if Bob is grounded
    public LayerMask groundLayer;       // Select the layer assigned to your ground/platforms

    [Header("Coin System Settings")]
    public int coinsCollected = 0;      // Tracks the current number of collected coins
    public TextMeshProUGUI coinsUIText; // Reference to the TMP text component on the screen

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Initialize the UI text counter at the start of the game
        UpdateCoinsUI();
    }

    void Update()
    {
        // STEP 2 REQUIREMENT: User Input - Button mashing mechanic to move forward
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PushSkate();
        }

        // STEP 2 REQUIREMENT: User Input - Jump mechanic (ONLY IF GROUNDED)
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            Jump();
        }

        // STEP 2 REQUIREMENT: User Input - Strafe Left (A Key)
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }

        // STEP 2 REQUIREMENT: User Input - Strafe Right (D Key)
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
    }

    // Checks if the player is touching the ground by casting a ray downwards
    bool IsGrounded()
    {
        // Casts a ray straight down from Bob's position
        return Physics.Raycast(transform.position, Vector3.down, groundDistance);
    }

    // This simulates the "paddling" or pushing the skate forward
    void PushSkate()
    {
        rb.AddForce(Vector3.forward * forwardImpulse, ForceMode.Impulse);
    }

    void Jump()
    {
        // Apply upward force for jumping
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    // Applies a short impulse to the left
    void MoveLeft()
    {
        rb.AddForce(Vector3.left * strafeImpulse, ForceMode.Impulse);
    }

    // Applies a short impulse to the right
    void MoveRight()
    {
        rb.AddForce(Vector3.right * strafeImpulse, ForceMode.Impulse);
    }

    // STEP 2 REQUIREMENT: UI Update according to game state
    public void AddCoin()
    {
        coinsCollected++;
        UpdateCoinsUI(); // Refresh the text on screen

        if (coinsCollected >= 3)
        {
            Debug.Log("Objective Completed: Bob collected 3 coins!");
        }
    }

    // Updates the visual text element on the Canvas interface
    private void UpdateCoinsUI()
    {
        if (coinsUIText != null)
        {
            coinsUIText.text = "Coins: " + coinsCollected + " / 3";
        }
    }

    // Fixed SetInputEnabled to avoid the "NotImplementedException" error
    public void SetInputEnabled(bool isEnabled)
    {
        this.enabled = isEnabled;
    }
}