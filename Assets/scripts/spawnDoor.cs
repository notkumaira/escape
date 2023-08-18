using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDoor : MonoBehaviour
{
    public float detectionRange = 1f; 
    public GameObject door;

    private void Update()
    {
        GameObject[] crates = GameObject.FindGameObjectsWithTag("crate");

        foreach (GameObject crate in crates)
        {
            float distance = Vector3.Distance(crate.transform.position, transform.position);
            if (distance <= detectionRange)
            {
                door.SetActive(true);
                return;
            }
        }

        door.SetActive(false);
    }
}
