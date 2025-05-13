using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SizeController : MonoBehaviour
{
    public Slider widthSlider;
    public Slider heightSlider;
    public Transform characterTransform;
    public TMP_Text widthText;
    public TMP_Text heightText;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = characterTransform.localScale;

        widthSlider.onValueChanged.AddListener(UpdateWidth);
        heightSlider.onValueChanged.AddListener(UpdateHeight);

        UpdateWidth(widthSlider.value);
        UpdateHeight(heightSlider.value);
    }

    void UpdateWidth(float value)
    {
        characterTransform.localScale = new Vector3(
            originalScale.x * value,
            characterTransform.localScale.y,
            characterTransform.localScale.z
        );

        if (widthText != null)
            widthText.text = $"Ширина: {value:F1}x";
    }

    void UpdateHeight(float value)
    {
        characterTransform.localScale = new Vector3(
            characterTransform.localScale.x,
            originalScale.y * value,
            characterTransform.localScale.z
        );

        if (heightText != null)
            heightText.text = $"Высота: {value:F1}x";
    }
}