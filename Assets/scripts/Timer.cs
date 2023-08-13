using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float moveDistance = 5f; // Distance to move the door
    public float moveSpeed = 2f; // Speed of movement
    public float openDuration = 5f; // Duration the door stays open

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private bool isOpen = false;

    private void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition + new Vector3(0f, moveDistance, 0f);
    }

    private void Update()
    {
        if (isOpen)
        {
            // Move the door to the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if the door has reached the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                StartCoroutine(CloseDoorAfterDelay());
            }
        }
        else
        {
            // Move the door back to its original position
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void OpenDoor()
    {
        isOpen = true;
        StopAllCoroutines();
        StartCoroutine(CloseDoorAfterDelay());
    }

    private IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(openDuration);
        isOpen = false;
    }
}
