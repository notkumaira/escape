using UnityEngine;
using UnityEngine.EventSystems;

public class movement : MonoBehaviour
{
    private Camera mainCamera;
    private bool isMoving;
    private Vector3 targetPosition;

    private bool isClimbing;

    public float movementSpeed = 5f;
    public float climbSpeed = 2f;

    public GameObject respawn;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && isMoving) // Check if not over a UI element
        {
            MoveToTargetPosition();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject()) // Check if not over a UI element
            {
                StartMoving();
            }
        }
    }

    private void StartMoving()
    {
        targetPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z; // Keep the same Z position as the GameObject
        isMoving = true;
    }

    private void MoveToTargetPosition()
    {
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            // Teleport the player to the respawn point's position
            transform.position = respawn.transform.position;
        }
    }
}
