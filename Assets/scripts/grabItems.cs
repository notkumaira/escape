using UnityEngine;

public class grabItems : MonoBehaviour
{
    public GameObject parentObject;
    public bool setOffChild = true;
    public GameObject key;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == parentObject)
        {
            transform.SetParent(parentObject.transform, true);

            if (setOffChild)
            {
                gameObject.SetActive(false);
            }
            key.SetActive(true);
            key.transform.SetAsFirstSibling();
        }
    }
}
