using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInventory : UICanvas
{
    [SerializeField] private InventorySlot[] inventorySlots;
    public void OnInit()
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            slot.OnInit();
        }
    }
    public void SwapHeroSpawn(InventorySlot oldSlot, InventorySlot newSlot)
    {
        if(oldSlot.inventoryName == "Team" && newSlot.inventoryName == "Team")
        {
            /*Debug.Log(oldSlot.HeroItem.image.sprite.name);
            Debug.Log(newSlot.HeroItem.image.sprite.name);*/
            UIManager.Ins.GetUI<CanvasGamePlay>().SetSpawnHeroForButton(oldSlot.HeroToSpawn, oldSlot.slotIndex, oldSlot.HeroItem.image.sprite, newSlot.HeroToSpawn, newSlot.slotIndex, newSlot.HeroItem.image.sprite);

        }
        if (oldSlot.inventoryName == "Team" && newSlot.inventoryName == "BackUp")
        {
            UIManager.Ins.GetUI<CanvasGamePlay>().SetSpawnHeroForButton(oldSlot.HeroToSpawn, oldSlot.slotIndex, oldSlot.HeroItem.image.sprite);
        }
        if (oldSlot.inventoryName == "BackUp" && newSlot.inventoryName == "Team")
        {
            UIManager.Ins.GetUI<CanvasGamePlay>().SetSpawnHeroForButton(newSlot.HeroToSpawn, newSlot.slotIndex, newSlot.HeroItem.image.sprite);
        }
        if(UIManager.Ins.IsOpened<CanvasGamePlay>())
        {
            UIManager.Ins.GetUI<CanvasGamePlay>().CloseDirectly();
        }
    }
    public void CloseInventory()
    {
        UIManager.Ins.CloseUIDirectly<CanvasInventory>();
    }
}
