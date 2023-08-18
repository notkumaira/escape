using UnityEngine;
using UnityEngine.EventSystems;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Quaternion initialRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        // Reset rotation to initial rotation
        transform.rotation = initialRotation;
    }
}
