using UnityEngine;

public class scaleDoor : MonoBehaviour
{
    public float moveDistance = 5f; // Distance to move the door
    public float moveSpeed = 2f;    // Speed of movement

    public GameObject door;

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private Vector3 closedPosition;
    private bool isOpen = false;

    private void Start()
    {
        originalPosition = door.transform.position;
        targetPosition = originalPosition + new Vector3(0f, moveDistance, 0f);
        closedPosition = originalPosition;
    }

    private void Update()
    {
        GameObject[] crates = GameObject.FindGameObjectsWithTag("crate");
        float shortestDistance = float.MaxValue;

        foreach (GameObject crate in crates)
        {
            float distanceToCrate = Vector2.Distance(crate.transform.position, transform.position);
            shortestDistance = Mathf.Min(shortestDistance, distanceToCrate);
        }

        if (shortestDistance <= 0.5f)
        {
            isOpen = true;
        }
        else
        {
            isOpen = false;
        }

        Vector3 targetDoorPosition = isOpen ? targetPosition : closedPosition;
        door.transform.position = Vector3.MoveTowards(door.transform.position, targetDoorPosition, moveSpeed * Time.deltaTime);
    }
}
