using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement settings
    public float forwardImpulse = 5f; // Power of each Space press
    public float jumpPower = 12f;    // Power of W press

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // STEP 2: User Input - Button mashing mechanic
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PushSkate();
        }

        // STEP 2: User Input - Jump mechanic
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }

    // This simulates the "paddling" or pushing the skate forward
    void PushSkate()
    {
        // If Bob goes backwards, change Vector3.forward to Vector3.back
        // This depends on how your character model was imported
        rb.AddForce(Vector3.forward * forwardImpulse, ForceMode.Impulse);
    }

    void Jump()
    {
        // Apply upward force for jumping
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    // Fixed SetInputEnabled to avoid the "NotImplementedException" error
    public void SetInputEnabled(bool isEnabled)
    {
        this.enabled = isEnabled;
    }
}