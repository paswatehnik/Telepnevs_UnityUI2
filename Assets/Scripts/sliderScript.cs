using UnityEngine;
using UnityEngine.UI;

public class ScaleSliderController : MonoBehaviour
{
    public Slider scaleSlider;

    private void Start()
    {
        scaleSlider.onValueChanged.AddListener(OnScaleChanged);
    }

    private void OnScaleChanged(float value)
    {
        if (ItemSelectionManager.Instance.selectedObject != null)
        {
            ItemSelectionManager.Instance.selectedObject.transform.localScale = Vector3.one * value;
        }
    }
}
