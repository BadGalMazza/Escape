using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueController))]
public class NPC : Interactive
{
    private DialogueController dialogueController;

    private void Awake()
    {
        dialogueController = GetComponent<DialogueController>();
    }

    public override void EmptyClicked()
    {
        if(!isDone)
            dialogueController.ShowDialogueFinish();
  /*      else if()
        {
            dialogueController.sho
        }
        else if()
        {


        }*/
        else
            dialogueController.ShowDialogueEmpty();

    }

    protected override void OnClickedAction()
    {
        dialogueController.ShowDialogueFinish();
    }
}
