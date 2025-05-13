using UnityEngine;
using UnityEngine.UI;

public class SizeController : MonoBehaviour
{
    public Slider sizeSlider;
    public GameObject character;
    public Text sizeText;

    void Start()
    {
        sizeSlider.onValueChanged.AddListener(ChangeSize);
        UpdateSizeText(sizeSlider.value);
    }

    void ChangeSize(float newSize)
    {
        character.transform.localScale = new Vector3(newSize, newSize, newSize);
        if (sizeText != null)
            UpdateSizeText(newSize);
    }

    void UpdateSizeText(float value)
    {
        sizeText.text = "Размер: " + (value * 100).ToString("0") + "%";
    }
}