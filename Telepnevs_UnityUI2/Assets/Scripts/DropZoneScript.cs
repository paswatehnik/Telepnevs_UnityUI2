using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class DropZoneScript : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Основные настройки")]
    [Tooltip("Тип одежды, принимаемый этой зоной")]
    public ClothingType zoneType;
    
    [Header("Ограничения")]
    [Tooltip("Максимальное количество предметов в этой зоне")]
    public int maxItems = 1;
    
    [Header("Визуальные настройки")]
    [Tooltip("Цвет подсветки при наведении")]
    [SerializeField] private Color highlightColor = new Color(0.8f, 1f, 0.8f, 0.3f);
    [Tooltip("Цвет ошибки при недопустимом перетаскивании")]
    [SerializeField] private Color errorColor = new Color(1f, 0.6f, 0.6f, 0.3f);

    private Image _zoneImage;

    void Awake()
    {
        _zoneImage = GetComponent<Image>();
        _zoneImage.color = Color.clear;
        
        if (GetComponent<RectTransform>() == null)
            Debug.LogError("Отсутствует RectTransform!", this);
    }
    public void OnDrop(PointerEventData eventData)
{
    GameObject dropped = eventData.pointerDrag;
    if (dropped == null) return;

    DragDropScript item = dropped.GetComponent<DragDropScript>();
    if (item != null && item.itemType == zoneType && transform.childCount < maxItems)
    {
        SnapToCenter(dropped);
        item.OnSuccessfulDrop();
    }
    else
    {
        StartCoroutine(ShowErrorIndicator());
    }
}


    private void SnapToCenter(GameObject dropped)
{
    // Привязываем к этой зоне
    dropped.transform.SetParent(transform);

    // Центрируем в зоне
    RectTransform droppedRect = dropped.GetComponent<RectTransform>();
    droppedRect.anchorMin = new Vector2(0.5f, 0.5f);
    droppedRect.anchorMax = new Vector2(0.5f, 0.5f);
    droppedRect.pivot = new Vector2(0.5f, 0.5f);
    droppedRect.anchoredPosition = Vector2.zero;
}
 
    public void OnPointerEnter(PointerEventData eventData)
    {
        DragDropScript item = eventData.pointerDrag?.GetComponent<DragDropScript>();
        if (item != null && item.itemType == zoneType && transform.childCount < maxItems)
        {
            _zoneImage.color = highlightColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _zoneImage.color = Color.clear;
    }

    private System.Collections.IEnumerator ShowErrorIndicator()
    {
        _zoneImage.color = errorColor;
        yield return new WaitForSeconds(0.5f);
        _zoneImage.color = Color.clear;
    }
}