using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupOption : MonoBehaviour
{
    public Transform targetObject; // Assign the target object in the Inspector
    public GameObject options; // Assign the "options" GameObject in the Inspector

    public float activationDistance = 5f;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, targetObject.position);

        if (distance <= activationDistance)
        {
            options.SetActive(true);
        }
        else
        {
            options.SetActive(false);
        }
    }
}
