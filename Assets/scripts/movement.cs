using UnityEngine;
using UnityEngine.EventSystems;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject respawn;

    private Animator animator;
    private Quaternion initialRotation;

    private void Start()
    {
        animator = GetComponent<Animator>();
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        // Update the animator parameters
        animator.SetFloat("MoveX", horizontalInput);
        animator.SetFloat("MoveY", verticalInput);

        if (moveDirection != Vector3.zero)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            transform.rotation = initialRotation;
        }

        // If no arrow keys are pressed, play the idle animation
        if (moveDirection == Vector3.zero)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
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
