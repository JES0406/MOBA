using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        InventoryManager.instance.Add(item);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
