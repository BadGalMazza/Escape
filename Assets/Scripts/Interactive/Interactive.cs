using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public ItemName requireItem;

    public bool isDone;

    public void CheckItem(ItemName itemName)
    {
        if (itemName == requireItem && !isDone)
        {
            string itemNameTring = itemName.ToString();
            isDone = true;
            
            EventHandler.CallItemUsedEvent(itemName);
            OnClickedAction(itemNameTring);
        }
    }
    protected virtual void OnClickedAction(string name)
    {

    }

    public virtual void EmptyClicked()
    {
        Debug.Log("empty");
    }
}