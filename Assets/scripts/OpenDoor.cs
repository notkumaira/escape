using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public float moveDistance = 5f; // Distance to move the door
    public float moveSpeed = 2f; // Speed of movement

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private Vector3 closedPosition;
    private bool isOpen = false;

    public Button openButton; // Reference to the UI button that opens the door

    private void Start()
    {
        originalPosition = transform.position;
        closedPosition = originalPosition;

        // Calculate the target position based on the angle
        float targetAngle = -35.955f;
        targetPosition = originalPosition + Quaternion.Euler(0f, 0f, targetAngle) * Vector3.down * moveDistance;

        openButton.onClick.AddListener(OpenDoorr);
    }

    private void Update()
    {
        if (isOpen)
        {
            // Move the door to the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            // Move the door back to its original position
            transform.position = Vector3.MoveTowards(transform.position, closedPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void OpenDoorr()
    {
        isOpen = true;
    }
}
