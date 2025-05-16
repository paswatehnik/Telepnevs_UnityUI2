using UnityEngine;
using System.Collections.Generic;

public class ItemSelectionManager : MonoBehaviour
{
    public static ItemSelectionManager Instance;

    public GameObject selectedObject;
    public ScaleSliderController scaleSliderController;

    private Dictionary<GameObject, float> _clothingSizes = new Dictionary<GameObject, float>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectObject(GameObject obj)
    {
        if (selectedObject != null)
        {
            _clothingSizes[selectedObject] = selectedObject.transform.localScale.x;
        }

        selectedObject = obj;

        float savedSize = _clothingSizes.ContainsKey(obj) ? _clothingSizes[obj] : 1f;
        obj.transform.localScale = Vector3.one * savedSize;

        if (scaleSliderController != null)
        {
            scaleSliderController.SetSliderValue(savedSize);
        }
    }
}