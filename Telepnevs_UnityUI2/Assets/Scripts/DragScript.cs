using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragDropScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Основные настройки")]
    [Tooltip("Тип одежды (должен соответствовать типу DropZone)")]
    public ClothingType itemType;
    
    [Header("Визуальные настройки")]
    [Tooltip("Прозрачность при перетаскивании (0-1)")]
    [Range(0.1f, 0.9f)] public float dragAlpha = 0.6f;
    [Tooltip("Цвет подсветки при выборе")]
    public Color selectedColor = new Color(0.8f, 0.8f, 1f, 1f);

    // Ссылки на компоненты
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Image _image;
    private Vector2 _startPosition;
    private Transform _startParent;
    private Color _originalColor;

    void Awake()
    {
        // Получаем необходимые компоненты
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _image = GetComponent<Image>();
        _originalColor = _image.color;
        
        // Проверяем обязательные компоненты
        if (_image == null) Debug.LogError("Отсутствует компонент Image!", this);
        if (_canvasGroup == null) Debug.LogError("Отсутствует CanvasGroup!", this);
    }

    /// <summary>
    /// Начало перетаскивания
    /// </summary>
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Запоминаем исходные параметры
        _startPosition = _rectTransform.anchoredPosition;
        _startParent = transform.parent;
        
        // Настраиваем визуал
        _canvasGroup.alpha = dragAlpha;
        _canvasGroup.blocksRaycasts = false;
        _image.color = selectedColor;
        
        // Перемещаем на верхний уровень иерархии
        transform.SetParent(transform.root);
    }

    /// <summary>
    /// Процесс перетаскивания
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        // Двигаем объект вслед за курсором с учетом масштаба Canvas
        _rectTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
    }

    /// <summary>
    /// Конец перетаскивания
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        // Восстанавливаем параметры
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        _image.color = _originalColor;

        // Если не попали в допустимую зону - возвращаем обратно
        if (transform.parent == transform.root)
        {
            transform.SetParent(_startParent);
            _rectTransform.anchoredPosition = _startPosition;
            
        }
        ItemSelectionManager.Instance.SelectObject(gameObject);
    }

    public void OnSuccessfulDrop()
    {
        Debug.Log($"Предмет {itemType} успешно размещен!");
    }
}
public enum ClothingType 
{ 
    hat,
    foot,
    body,      // Верхняя одежда
    leg,      // Брюки
    shoes       // Обувь
}