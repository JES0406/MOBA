using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    public Item item;

    public void AddItem(Item newItem)
    {
        if (newItem == null)
        {
            Debug.Log("Item is null");
            return;
        }
        Debug.Log("item icon: " + newItem.icon);
        this.item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
