using UnityEngine;
using UnityEngine.EventSystems;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject respawn;

    private Quaternion initialRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Reset rotation to initial rotation
        transform.rotation = initialRotation;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            transform.position = respawn.transform.position;
        }
    }
}
