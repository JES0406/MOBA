using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform inventoryParent;
    InventoryManager inventory;

    InventorySlot[] slots;

    void Awake()
    {
        inventory = InventoryManager.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = inventoryParent.GetComponentsInChildren<InventorySlot>();
    }

    // Start is called before the first frame update
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
