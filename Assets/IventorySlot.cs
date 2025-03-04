using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public string inventoryName;
    public int slotIndex;
    private Hero heroToSpawn;
    [SerializeField] private HeroItem heroItem;
    // public ButtonSpawnHero buttonSpawnHero;
    public void OnInit()
    {
        heroToSpawn = heroItem.HeroToSpawn;
    }
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        HeroItem draggableItem = dropped.GetComponent<HeroItem>();

        InventorySlot oldSlot = draggableItem.originalSlot;
        InventorySlot newSlot = this;
        GridLayoutGroup oldGrid = oldSlot.GetComponentInParent<GridLayoutGroup>();
        GridLayoutGroup newGrid = newSlot.GetComponentInParent<GridLayoutGroup>();
        if (transform.childCount > 0)
        {
            HeroItem existingItem = heroItem;

            oldSlot.SetHeroToSpawn(existingItem.HeroToSpawn);
            newSlot.SetHeroToSpawn(draggableItem.HeroToSpawn);
            oldSlot.SetHeroItem(existingItem);
            newSlot.SetHeroItem(draggableItem);
            UIManager.Ins.GetUI<CanvasInventory>().SwapHeroSpawn(oldSlot ,newSlot);
                
            existingItem.transform.SetParent(oldSlot.transform);
            existingItem.transform.localPosition = Vector3.zero;
            existingItem.parentAfterDrag = oldSlot.transform;
                                            
            draggableItem.parentAfterDrag = newSlot.transform;
            draggableItem.transform.SetParent(newSlot.transform);
            draggableItem.transform.localPosition = Vector3.zero;



            SwapCellSize(oldGrid, newGrid);
            
            InventoryManager.UpdateSlot(oldSlot, existingItem.gameObject.name);
            InventoryManager.UpdateSlot(newSlot, draggableItem.gameObject.name);
        }
        else
        {
            draggableItem.parentAfterDrag = newSlot.transform;
            SwapCellSize(oldGrid, newGrid);
          
            InventoryManager.UpdateSlot(oldSlot, null);
            InventoryManager.UpdateSlot(newSlot, draggableItem.gameObject.name);
        }

        
        LevelManager.Ins.SaveGame();

    }
    private void SwapCellSize(GridLayoutGroup grid1, GridLayoutGroup grid2)
    {
        Vector2 tempSize = grid1.cellSize;
        grid1.cellSize = grid2.cellSize;
        grid2.cellSize = tempSize;
    }

    public void SetHeroToSpawn(Hero hero)
    {
        heroToSpawn = hero;
    }
    public void SetHeroItem(HeroItem heroItem)
    {
        this.heroItem = heroItem;
    }
    public Hero HeroToSpawn => heroToSpawn;
    public HeroItem HeroItem => heroItem;
}
