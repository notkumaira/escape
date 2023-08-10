using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabItems : MonoBehaviour
{
    public GameObject parentObject;
    public bool setOffChild = true;
    public GameObject key;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding GameObject is the specific parentObject
        if (collision.gameObject == parentObject)
        {
            // Make this GameObject a child of the parentObject
            transform.SetParent(parentObject.transform, true);

            // Optionally deactivate the child GameObject
            if (setOffChild)
            {
                gameObject.SetActive(false);
            }
            key.SetActive(true);
            key.transform.SetAsFirstSibling();
        }
    }
}
