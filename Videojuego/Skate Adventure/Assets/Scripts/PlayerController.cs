using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float jumpForce = 6.5f;
    public float acceleration = 12f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.3f;
    public LayerMask groundLayer;

    [Header("Extra Gravity")]
    public float fallMultiplier = 1.8f;
    public float lowJumpMultiplier = 1.3f;

    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 currentMove;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck is not assigned.");
            return;
        }

        isGrounded = Physics.CheckSphere(
            groundCheck.position,
            groundRadius,
            groundLayer
        );

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x,
                0f,
                rb.linearVelocity.z
            );

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Corrected for 90° rotated character
        Vector3 move = (transform.right * v - transform.forward * h).normalized;

        currentMove = Vector3.Lerp(
            currentMove,
            move * moveSpeed,
            acceleration * Time.fixedDeltaTime
        );

        rb.linearVelocity = new Vector3(
            currentMove.x,
            rb.linearVelocity.y,
            currentMove.z
        );

        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up *
                                 Physics.gravity.y *
                                 (fallMultiplier - 1) *
                                 Time.fixedDeltaTime;
        }
        else if (rb.linearVelocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.linearVelocity += Vector3.up *
                                 Physics.gravity.y *
                                 (lowJumpMultiplier - 1) *
                                 Time.fixedDeltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }
}