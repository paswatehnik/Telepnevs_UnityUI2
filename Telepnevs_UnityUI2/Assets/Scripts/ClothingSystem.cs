using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ClothingSystem : MonoBehaviour
{
    [System.Serializable]
    public class Category
    {
        public string name;
        public Toggle toggle;
        public Transform itemsParent;
        public List<GameObject> clothingItems;
    }

    public List<Category> categories;

    void Start()
    {
        foreach (var category in categories)
        {
            category.toggle.onValueChanged.AddListener((isOn) =>
            {
                category.itemsParent.gameObject.SetActive(isOn);
            });
        }
    }

    
}