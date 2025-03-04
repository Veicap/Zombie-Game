using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HeroItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public InventorySlot originalSlot;
    public CanvasInventory canvasInventory;
    [SerializeField] private Hero heroToSpawn;
    
    public Image image; 

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        originalSlot = parentAfterDrag.GetComponent<InventorySlot>();
        transform.SetParent(canvasInventory.transform);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

    public Hero HeroToSpawn => heroToSpawn;
}
