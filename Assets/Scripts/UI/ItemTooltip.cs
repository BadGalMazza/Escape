using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public Text itemNameText;

    public void UpdateItemName(ItemName itemName)
    {
        itemNameText.text = itemName switch
        {
            ItemName.Key => "A Key",
            ItemName.Charger => "A charger",
            ItemName.Screwdriver => "A Screwdriver>",
            ItemName.Wonster => "Energy Drink",
            ItemName.scissors => "Cut something",
            ItemName.pin => "A bobby pin",
            _ => ""
        };
    }
}
