using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObjects : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 5f;

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isMoving;

    private void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition;
        isMoving = false;
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveObject();
        }
    }

    private void MoveObject()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }

    public void MoveLeft()
    {
        if (!isMoving)
        {
            targetPosition = transform.position + Vector3.left * moveDistance;
            isMoving = true;
        }
    }

    public void MoveRight()
    {
        if (!isMoving)
        {
            targetPosition = transform.position + Vector3.right * moveDistance;
            isMoving = true;
        }
    }
    
    public void MoveUp()
    {
        if (!isMoving)
        {
            targetPosition = targetPosition + Vector3.up * moveDistance;
            isMoving = true;
        }
    }

    public void MoveDown()
    {
        if (!isMoving)
        {
            targetPosition = targetPosition + Vector3.down * moveDistance;
            isMoving = true;
        }
    }
}
