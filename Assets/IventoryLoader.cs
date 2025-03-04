using UnityEngine;

public class InventoryLoader : MonoBehaviour
{
    public string inventoryName;
    public InventorySlot[] slots;

    public void Start()
    {
        LoadInventory();
    }

    public void LoadInventory()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            string key = $"{inventoryName}_{i}";

            if (LevelManager.Ins.data.slotToItemMap.TryGetValue(key, out string itemName))
            {
                GameObject itemPrefab = Resources.Load<GameObject>($"Items/{itemName}");
                if (itemPrefab != null)
                {
                    GameObject newItem = Instantiate(itemPrefab, slots[i].transform);
                    newItem.GetComponent<HeroItem>().parentAfterDrag = slots[i].transform;
                }
            }
        }
    }
}
