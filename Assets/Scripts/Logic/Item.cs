using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemName itemName;

    public void ItemClicked()
    {
        InventoryMaanager.Instance.AddItem(itemName);
        this.gameObject.SetActive(false);
    }
 
}
