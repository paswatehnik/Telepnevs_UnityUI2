using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    [SerializeField] private string _acceptableType;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        if (dropped == null) return;

        DragAndDrop item = dropped.GetComponent<DragAndDrop>();
        if (item != null && item.GetItemType() == _acceptableType)
        {
            dropped.transform.SetParent(transform);
            dropped.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;

            StartCoroutine(ScaleAnimation(dropped.transform));
        }
    }

    private System.Collections.IEnumerator ScaleAnimation(Transform target)
    {
        float duration = 0.2f;
        Vector3 startScale = target.localScale;
        Vector3 endScale = startScale * 1.1f;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            target.localScale = Vector3.Lerp(startScale, endScale, t / duration);
            yield return null;
        }
        target.localScale = endScale;
    }
}