using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSwitcher : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public Image characterImage;
    public Sprite[] characterSprites;

    void Start()
    {
        dropdown.onValueChanged.AddListener(ChangeCharacter);
    }

    void ChangeCharacter(int index)
    {
        if (index >= 0 && index < characterSprites.Length)
        {
            characterImage.sprite = characterSprites[index];
        }
    }
}