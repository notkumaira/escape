using UnityEngine;

public class KeyOpensDoor : MonoBehaviour
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
        door.transform.Translate(Vector3.up * 7f);
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
