using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float moveDistance = 5f;
    public float moveSpeed = 2f;

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private bool movingRight = true;

    private void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition + new Vector3(moveDistance, 0f, 0f);
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            Vector3 destination = movingRight ? targetPosition : originalPosition;
            Vector3 direction = destination - transform.position;

            float startTime = Time.time;
            float journeyLength = direction.magnitude;

            while (transform.position != destination)
            {
                float distanceCovered = (Time.time - startTime) * moveSpeed;
                float fractionOfJourney = distanceCovered / journeyLength;
                transform.position = Vector3.Lerp(transform.position, destination, fractionOfJourney);
                yield return null;
            }

            movingRight = !movingRight;
            float randomWaitTime = Random.Range(0f, 10f);
            float elapsedTime = 0f;

            while (elapsedTime < randomWaitTime)
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
