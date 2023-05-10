using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private Dictionary<ItemName, bool> itemAvaliableDict = new Dictionary<ItemName, bool>();
    private Dictionary<string, bool> interactiveStateDict = new Dictionary<string, bool>();

    private void OnEnable()
    {
        EventHandler.BeforeSceneUnloadEvent += OnBeforeSceneUnloadEvent;
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.UpdateUIEvent += OnUpdateUIEvent;
    }

    private void OnDisable()
    {
        EventHandler.BeforeSceneUnloadEvent -= OnBeforeSceneUnloadEvent;
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
        EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
    }

    private void OnBeforeSceneUnloadEvent()
    {
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvaliableDict.ContainsKey(item.itemName))
                itemAvaliableDict.Add(item.itemName, true);
        }
        foreach (var item in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDict.ContainsKey(item.name))
                interactiveStateDict[item.name] = item.isDone;
            else
                interactiveStateDict.Add(item.name, item.isDone);
        }
    }

    private void OnAfterSceneLoadedEvent()
    {
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvaliableDict.ContainsKey(item.itemName))
                itemAvaliableDict.Add(item.itemName, true);
            else
                item.gameObject.SetActive(itemAvaliableDict[item.itemName]);
        }
        foreach (var item in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDict.ContainsKey(item.name))
                item.isDone = interactiveStateDict[item.name];
            else
                interactiveStateDict.Add(item.name, item.isDone);
        }
    }

    private void OnUpdateUIEvent(ItemDetails itemDetails, int arg2)
    {
        if(itemDetails != null)
        {
            itemAvaliableDict[itemDetails.itemName] = false;
        }
    }
}