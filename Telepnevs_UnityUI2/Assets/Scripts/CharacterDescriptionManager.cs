using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterDescriptionManager : MonoBehaviour
{
    [System.Serializable]
    public class CharacterInfo
    {
        public string characterName;
        [TextArea(3, 10)]
        public string description;
        public Sprite characterSprite;
    }

    public CharacterInfo[] characters;
    public TMP_Dropdown characterDropdown;
    public TMP_Text descriptionText;
    public Image characterImage;

    void Start()
    {
        characterDropdown.ClearOptions();
        foreach (CharacterInfo character in characters)
        {
            characterDropdown.options.Add(new TMP_Dropdown.OptionData(character.characterName));
        }

        characterDropdown.onValueChanged.AddListener(UpdateDescription);
        UpdateDescription(0); 
    }

    void UpdateDescription(int characterIndex)
    {
        if (characterIndex < 0 || characterIndex >= characters.Length) return;

        descriptionText.text = characters[characterIndex].description;

        if (characterImage != null)
        {
            characterImage.sprite = characters[characterIndex].characterSprite;
        }
    }
}