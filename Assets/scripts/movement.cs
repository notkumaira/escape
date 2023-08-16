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

    private Quaternion defaultRotation;

    private void Start()
    {
        mainCamera = Camera.main;
        defaultRotation = transform.rotation;
    }

    private void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && isMoving)
        {
            MoveToTargetPosition();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject()) 
            {
                StartMoving();
            }
        }
    }

    private void StartMoving()
    {
        targetPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z; 
        isMoving = true;
    }

    private void MoveToTargetPosition()
    {
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        transform.rotation = defaultRotation;

        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            transform.position = respawn.transform.position;
        }
    }
}
