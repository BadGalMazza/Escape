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
    private void Awake()
    {
        dialogueController = GetComponent<DialogueController>();
    }

    public override void EmptyClicked()
    {
        Debug.Log("EmptyClicked" + count);

        if (iseatfood && isdrinkwater)
        {

            dialogueController.ShowDialogueFinish();
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

    protected override void OnClickedAction(string name)
    {
        Debug.Log("OnClickedAction" + name + count);
        if (name == "Wonster")
        {
            count = 1;

            isdrinkwater = true;
        }
        else if (name == "Food")
        {
            count = 2;
            iseatfood = true;
        }
        //dialogueController.ShowDialogueFinish();
    }
}
