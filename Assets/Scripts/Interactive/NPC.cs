using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueController))]
public class NPC : Interactive
{
    private DialogueController dialogueController;
    public int count = 0;
    public bool iseatfood = false;
    public bool isdrinkwater = false;
    public bool isShowText = true;

    public bool isBatteryBlue = false;
    public bool isBatteryRed = false;

    public GameObject red;
    public GameObject blue;
    public MoveCompass moveCompass;

    public GameObject keyPrefab;
    public bool hasKeySpawned = false;

    private void Awake()
    {
        dialogueController = GetComponent<DialogueController>();
        loadByPlayerPrefs();
       if(!isShowText)
        {
            blue.SetActive(isBatteryBlue);
            red.SetActive(isBatteryRed);
        }
    }
    // ?????PlayerPrefs
    private void loadByPlayerPrefs()
    {

        count = PlayerPrefs.GetInt("count");
        iseatfood = PlayerPrefs.GetInt("iseatfood") == 1 ? true : false;
        isdrinkwater = PlayerPrefs.GetInt("isdrinkwater") == 1 ? true : false;
        isBatteryBlue = PlayerPrefs.GetInt("isBatteryBlue") == 1 ? true : false;
        isBatteryRed = PlayerPrefs.GetInt("isBatteryRed") == 1 ? true : false;
    }
    public override void EmptyClicked()
    {
        Debug.Log("EmptyClicked" + count);
        if (isShowText)
        {


            if (iseatfood && isdrinkwater)
            {

                dialogueController.ShowDialogueFinish();
                // 只有当钥匙还未生成时，才生成钥匙
                if (!hasKeySpawned)
                {
                    Instantiate(keyPrefab, transform.position, Quaternion.identity);
                    hasKeySpawned = true;  // 钥匙已生成
                }
            }
            else
            {


                if (count == 0)
                    dialogueController.ShowDialogueEmpty();
                else if (count == 1)
                    dialogueController.ShowdialogueFinishWater();
                else if (count == 2)
                    dialogueController.ShowdialogueFinishFood();

            }
        }

    }

    protected override void OnClickedAction(string name)
    {
        Debug.Log("OnClickedAction" + name + count);
        if (name == "Wonster")
        {
            count = 1;

            isdrinkwater = true;
            PlayerPrefs.SetInt("isdrinkwater", isdrinkwater ? 1 : 0);
            PlayerPrefs.SetInt("count", count);

        }
        else if (name == "Food")
        {
            count = 2;
            iseatfood = true;
            PlayerPrefs.SetInt("iseatfood", iseatfood ? 1 : 0);
            PlayerPrefs.SetInt("count", count);

        }
        if(!isShowText)
        {

       
        if (name == "BatteryBlue")
        {
            // count = 1;

            isBatteryBlue = true;
            PlayerPrefs.SetInt("isBatteryBlue", isBatteryBlue ? 1 : 0);
            blue.SetActive(isBatteryBlue);
           

        }
        else if (name == "BatteryRed")
        {
            // count = 2;
            isBatteryRed = true;
            PlayerPrefs.SetInt("isBatteryRed", isBatteryRed ? 1 : 0);
            red.SetActive(isBatteryRed);

        }

        Debug.Log("isBatteryBlue" + isBatteryBlue + "ddd" + PlayerPrefs.GetInt("isBatteryBlue")); ;

        if (isBatteryBlue && isBatteryRed)
        {
            BatteryIsdone();
        }
        }
        PlayerPrefs.Save();

        //dialogueController.ShowDialogueFinish();
    }

    public void BatteryIsdone()
    {
        moveCompass.isgetbuttery = true;
        Debug.Log("done");

    }
}
