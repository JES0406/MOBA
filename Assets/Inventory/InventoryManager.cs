using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Singleton structure
    public static InventoryManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    public delegate void OnItemChanged(); // Delegate is a type safe function pointer
    public OnItemChanged onItemChangedCallback; // Callback function

    public int inventorySpace = 8;
    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        if (items.Count >= inventorySpace)
        {
            Debug.Log("Not enough room.");
            return;
        }

        items.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

        return;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
