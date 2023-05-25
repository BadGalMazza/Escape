using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SlotUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image itemImage;

    public ItemTooltip tooltip;

    private ItemDetails currentItem;

    private bool isSelected;

    public void SetItem(ItemDetails itemDetails)
    {
        currentItem = itemDetails;
        this.gameObject.SetActive(true);
        itemImage.sprite = itemDetails.itemSprite;
        itemImage.SetNativeSize();
    }
    public void SetEmpty()
    {
        this.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
        isSelected = !isSelected;
        EventHandler.CallItemSelectedEvent(currentItem, isSelected);
        Debug.Log(currentItem.itemName);
        Scene gameScene = SceneManager.GetSceneByBuildIndex(5);
        // Debug.Log(gameScene.name);
        //????
        GameObject npc = gameScene.GetRootGameObjects().FirstOrDefault(x => x.name == "NPC");
        GameObject npc1 = gameScene.GetRootGameObjects().FirstOrDefault(x => x.name == "NPC1");
        Debug.Log(gameScene.name);
        if (currentItem.itemName.ToString() == "Wonster")
        {
            Debug.Log("aaa");
            npc.SetActive(true);
            npc.GetComponent<NPC>().count = npc1.GetComponent<NPC>().count;
            npc.GetComponent<NPC>().iseatfood = npc1.GetComponent<NPC>().iseatfood;
            npc.GetComponent<NPC>().isdrinkwater = npc1.GetComponent<NPC>().isdrinkwater;
            npc1.SetActive(false);
        }
        else if (currentItem.itemName.ToString() == "Food")
        {
            Debug.Log("bbb");
            npc1.SetActive(true);
            npc1.GetComponent<NPC>().count = npc.GetComponent<NPC>().count;
            npc1.GetComponent<NPC>().iseatfood = npc.GetComponent<NPC>().iseatfood;
            npc1.GetComponent<NPC>().isdrinkwater = npc.GetComponent<NPC>().isdrinkwater;
            npc.SetActive(false);

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.gameObject.activeInHierarchy)
        {
            tooltip.gameObject.SetActive(true);
            tooltip.UpdateItemName(currentItem.itemName);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }
}
