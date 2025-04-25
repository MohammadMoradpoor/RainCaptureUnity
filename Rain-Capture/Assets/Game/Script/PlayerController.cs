using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;
    public bool useMouseControl = false;
    public KeyCode toggleControlKey = KeyCode.T;

    [Header("Screen Boundaries")]
    public float minX = -8f;
    public float maxX = 8f;

    private float targetX;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        targetX = transform.position.x;
    }

    void Update()
    {
        // Toggle between mouse and keyboard control
        if (Input.GetKeyDown(toggleControlKey))
        {
            useMouseControl = !useMouseControl;
        }

        if (useMouseControl)
        {
            HandleMouseControl();
        }
        else
        {
            HandleKeyboardControl();
        }

        // Apply screen boundaries
        ClampPositionToScreenBoundaries();
    }

    void HandleMouseControl()
    {
        if (Input.GetMouseButton(0)) // Only move when mouse button is pressed
        {
            Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            targetX = mousePos.x;
        }
        
        // Smooth horizontal movement toward target position
        float newX = Mathf.Lerp(transform.position.x, targetX, moveSpeed * Time.deltaTime);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    void HandleKeyboardControl()
    {
        float moveX = Input.GetAxis("Horizontal");

        // Apply horizontal movement only if there's input
        if (moveX != 0)
        {
            transform.position += new Vector3(moveX * moveSpeed * Time.deltaTime, 0, 0);
        }
    }

    void ClampPositionToScreenBoundaries()
    {
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
