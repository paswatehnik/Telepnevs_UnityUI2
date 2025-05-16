using UnityEngine;
using UnityEngine.UI;

public class CategoryManager : MonoBehaviour
{
    [System.Serializable]
    public class Category
    {
        public Toggle toggle;
        public GameObject content;
    }

    public Category[] categories;

    void Start()
    {
        foreach (var category in categories)
        {
            category.content.SetActive(category.toggle.isOn);
            category.toggle.onValueChanged.AddListener((isOn) => 
            {
                category.content.SetActive(isOn);
            });
        }
    }
}