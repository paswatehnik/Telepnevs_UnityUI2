using UnityEngine;
using UnityEngine.EventSystems;

public class DropZoneScript : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public ClothingType zoneType;
    public int maxItems = 1;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        var item = eventData.pointerDrag.GetComponent<DragDropScript>();
        if (item != null && item.itemType == zoneType && transform.childCount < maxItems)
        {
            SnapToCenter(eventData.pointerDrag);
        }
    }

    private void SnapToCenter(GameObject dropped)
    {
        dropped.transform.SetParent(transform);
        
        RectTransform droppedRect = dropped.GetComponent<RectTransform>();
        droppedRect.anchoredPosition = Vector2.zero;
        droppedRect.anchorMin = Vector2.one * 0.5f;
        droppedRect.anchorMax = Vector2.one * 0.5f;
        droppedRect.pivot = Vector2.one * 0.5f;
    }

    public void OnPointerEnter(PointerEventData eventData) { }

    public void OnPointerExit(PointerEventData eventData) { }
}