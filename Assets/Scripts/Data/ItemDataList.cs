using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataList", menuName = "Inventory/ItemDataList")]

public class ItemDataList : ScriptableObject
{
    public List<ItemDetails> itemDetailsList;
    
    public ItemDetails GetItemDetails(ItemName itemName)
    {
        return itemDetailsList.Find(i => i.itemName == itemName);
    }
}

[System.Serializable]
public class ItemDetails
{
    public ItemName itemName;
    public Sprite itemSprite;
}