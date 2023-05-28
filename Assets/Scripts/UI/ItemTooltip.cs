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
            ItemName.Charger => "Phone charger",
            ItemName.Screwdriver => "A Screwdriver>",
            ItemName.Wonster => "Energy Drink",
            ItemName.Food => "Left over pizza",
            ItemName.scissors => "Cut something",
            ItemName.BatteryBlue => "BatteryBlue",
            ItemName.BatteryRed => "BatteryRed",
            ItemName.pin => "A bobby pin",
            _ => ""
        };
    }
}
