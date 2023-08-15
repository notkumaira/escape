using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOpensDoorII : MonoBehaviour
{
    public GameObject door;
    public GameObject displayMessage;

    private bool hasItemChild = false;

    private void Start()
    {
        displayMessage.SetActive(false);
    }

    public void CheckAndInteract()
    {
        hasItemChild = CheckForItemChild(transform);

        if (hasItemChild)
        {
            MoveDoor();
        }
        else
        {
            DisplayMessage();
        }
    }

    private bool CheckForItemChild(Transform parent)
    {
        Component[] componentsInChildren = parent.GetComponentsInChildren(typeof(Transform), true);
        foreach (Component component in componentsInChildren)
        {
            if (component.CompareTag("item"))
            {
                return true;
            }
        }
        return false;
    }

    private void MoveDoor()
    {
        door.transform.Translate(Vector3.left * 7f);
    }

    private void DisplayMessage()
    {
        displayMessage.SetActive(true);
        Invoke(nameof(TurnOffMessage), 3f);
    }

    private void TurnOffMessage()
    {
        displayMessage.SetActive(false);
    }
}
