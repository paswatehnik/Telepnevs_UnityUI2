using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class DragDropScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ClothingType itemType;

    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Vector2 _startPosition;
    private Transform _startParent;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        
        _canvasGroup = GetComponent<CanvasGroup>();
        if (_canvasGroup == null)
        {
            _canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPosition = _rectTransform.anchoredPosition;
        _startParent = transform.parent;
        
        _canvasGroup.blocksRaycasts = false;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GetComponentInParent<Canvas>() is Canvas canvas)
        {
            _rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        
        if (transform.parent == transform.root)
        {
            transform.SetParent(_startParent);
            _rectTransform.anchoredPosition = _startPosition;
        }
        
        if (ItemSelectionManager.Instance != null)
        {
            ItemSelectionManager.Instance.SelectObject(gameObject);
        }
    }
}

public enum ClothingType 
{ 
    Hat,
    Top,
    Pants,
    Shoes
}