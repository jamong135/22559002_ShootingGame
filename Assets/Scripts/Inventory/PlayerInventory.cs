using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    public int bagSlotCount = 12;
    public int equipSlotCount = 3;

    public List<InventoryItem> bagItems = new List<InventoryItem>();
    public List<InventoryItem> equipItems = new List<InventoryItem>();

    public void FillEmptySlots(List<InventoryItem> list, int slotCount)
    {
       while (list.Count < slotCount)
        {
            list.Add(null); 
        }
    }

    private void Awake()
    {
        Instance = this;

        bagItems.Clear();
        equipItems.Clear();

        FillEmptySlots(bagItems, bagSlotCount);
        FillEmptySlots(equipItems, equipSlotCount);
    }

    public bool AddItem(ItemData itemData, int count = 1)
    {
        if (itemData == null) return false;
        if (count <= 0) return false;

        if (itemData.canStack)
        {
            for (int i = 0; i < bagItems.Count; i++)
            {
                InventoryItem item = bagItems[i];

                if (item != null && item.data == itemData && item.count < itemData.maxStack)
                {
                    int addCount = Mathf.Min(count, itemData.maxStack - item.count);
                    item.count += addCount;
                    count -= addCount;

                    if (count <= 0)
                    {
                        Debug.Log(itemData.itemName + "스택 추가 성공");
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public void MoveItem(List<InventoryItem> fromList, int fromIndex, List<InventoryItem> toList, int toIndex)
    {
        // from 슬롯과 to 슬롯의 아이템을 서로 바꾸기
    }
}
