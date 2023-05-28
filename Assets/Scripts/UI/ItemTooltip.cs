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
            ItemName.Key => "A Key" + "                         What’s it for?",
            ItemName.Charger => "Phone charger",
            ItemName.Screwdriver => "A Screwdriver",
            ItemName.Wonster => "Energy Drink" + "              Wonster? That sounds familiar...",
            ItemName.Food => "Left over pizza" + "              Ew...",
            ItemName.scissors => "A scissor" + "                Maybe I can cut something?",
            ItemName.BatteryBlue => "BatteryBlue",
            ItemName.BatteryRed => "BatteryRed",
            ItemName.pin => "A paper click" + "                 I wonder what this can do?",
            _ => ""
        };
    }
}
