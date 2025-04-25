using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float acceleration = 50f;
    [SerializeField] private float deceleration = 10f;

    [Header("Screen Boundaries")]
    public float minX = -8f;
    public float maxX = 8f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Set drag to prevent excessive sliding
        rb.linearDamping = 5f;
    }

    void FixedUpdate()
    {
        HandleMovement();
        ClampPositionToScreenBoundaries();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        
        if (Mathf.Abs(moveX) > 0.1f)
        {
            // When actively moving, use acceleration for more responsive control
            float targetVelocityX = moveX * moveSpeed;
            float velocityChange = targetVelocityX - rb.linearVelocity.x;
            float force = velocityChange * acceleration;
            
            rb.AddForce(new Vector2(force, 0));
        }
        else if (rb.linearVelocity.magnitude > 0.1f)
        {
            // Apply deceleration when no input to stop more quickly
            rb.AddForce(-rb.linearVelocity.normalized * deceleration);
        }
    }

    void ClampPositionToScreenBoundaries()
    {
        Vector2 currentPosition = rb.position;
        float clampedX = Mathf.Clamp(currentPosition.x, minX, maxX);
        rb.position = new Vector2(clampedX, currentPosition.y);
    }
}
