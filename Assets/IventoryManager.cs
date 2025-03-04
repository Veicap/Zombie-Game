using UnityEngine;

public static class InventoryManager
{
    public static void UpdateSlot(InventorySlot slot, string itemName)
    {
        string key = $"{slot.inventoryName}_{slot.slotIndex}";

        if (string.IsNullOrEmpty(itemName))
        {
            LevelManager.Ins.data.slotToItemMap.Remove(key);
            //Debug.Log("Remove Key");
        }
        else
        {
            LevelManager.Ins.data.slotToItemMap[key] = itemName;
            /*Debug.Log("Add key");
            Debug.Log(LevelManager.Ins.data.slotToItemMap.Values.Count);*/
        }
    }
}
