using System;
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

    public TransitionManager transitionManager;



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
        Scene gameScene = SceneManager.GetSceneByBuildIndex(transitionManager.index);
        // Debug.Log(gameScene.name);
        //????

        Debug.Log(gameScene.name);

        GameObject npc = gameScene.GetRootGameObjects().FirstOrDefault(x => x.name == "NPC");
        GameObject npc1 = gameScene.GetRootGameObjects().FirstOrDefault(x => x.name == "NPC1");
        Debug.Log(gameScene.name);
        if (transitionManager.index == 5)
        {


            if (currentItem.itemName.ToString() == "Wonster")
            {
                if (PlayerPrefs.HasKey("iseatfood") && PlayerPrefs.HasKey("isdrinkwater") && PlayerPrefs.HasKey("count"))
                {



                    Debug.Log("aaa");
                    npc.SetActive(true);
                    npc.GetComponent<NPC>().count = PlayerPrefs.GetInt("count");
                    npc.GetComponent<NPC>().iseatfood = PlayerPrefs.GetInt("iseatfood") == 1 ? true : false;
                    npc.GetComponent<NPC>().isdrinkwater = PlayerPrefs.GetInt("isdrinkwater") == 1 ? true : false;
                    npc1.SetActive(false);

                }
            }
            else if (currentItem.itemName.ToString() == "Food")
                if (PlayerPrefs.HasKey("iseatfood") && PlayerPrefs.HasKey("isdrinkwater") && PlayerPrefs.HasKey("count"))
                {
                    {
                        Debug.Log("bbb");
                        npc1.SetActive(true);
                        npc1.GetComponent<NPC>().count = PlayerPrefs.GetInt("count");
                        npc1.GetComponent<NPC>().iseatfood = PlayerPrefs.GetInt("iseatfood") == 1 ? true : false;
                        npc1.GetComponent<NPC>().isdrinkwater = PlayerPrefs.GetInt("isdrinkwater") == 1 ? true : false;
                        npc.SetActive(false);
                    }
                }
        }
        else if (transitionManager.index == 12)
        {

            if (currentItem.itemName.ToString() == "BatteryBlue")
            {
                if (PlayerPrefs.HasKey("isBatteryBlue") && PlayerPrefs.HasKey("isBatteryRed"))
                {
                    Debug.Log("aaa1");
                    Debug.Log(npc);
                    npc.SetActive(true);
                    Debug.Log("blue" + PlayerPrefs.GetInt("isBatteryBlue"));
                    // npc.GetComponent<NPC>().count = npc1.GetComponent<NPC>().count;
                    npc.GetComponent<NPC>().isBatteryBlue = PlayerPrefs.GetInt("isBatteryBlue") == 1 ? true : false;
                    npc.GetComponent<NPC>().isBatteryRed = PlayerPrefs.GetInt("isBatteryRed") == 1 ? true : false;
                    npc1.SetActive(false);

                }
            }
            else if (currentItem.itemName.ToString() == "BatteryRed")
            {
                if (PlayerPrefs.HasKey("isBatteryBlue") && PlayerPrefs.HasKey("isBatteryRed"))
                {
                    Debug.Log("bbb1");
                    Debug.Log(npc1);
                    Debug.Log("blue" + PlayerPrefs.GetInt("isBatteryBlue"));
                    npc1.SetActive(true);
                    //    npc1.GetComponent<NPC>().count = npc.GetComponent<NPC>().count;
                    npc1.GetComponent<NPC>().isBatteryBlue = PlayerPrefs.GetInt("isBatteryBlue") == 1 ? true : false;
                    npc1.GetComponent<NPC>().isBatteryRed = PlayerPrefs.GetInt("isBatteryRed") == 1 ? true : false;
                    npc.SetActive(false);
                }

            }

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

    public void savedate()
    {


    }
}
