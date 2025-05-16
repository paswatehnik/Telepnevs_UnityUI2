using UnityEngine;

public class ItemSelectionManager : MonoBehaviour
{
    public static ItemSelectionManager Instance { get; private set; }

    public GameObject selectedObject;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void SelectObject(GameObject obj)
    {
        selectedObject = obj;
    }

    public void Deselect()
    {
        selectedObject = null;
    }
}