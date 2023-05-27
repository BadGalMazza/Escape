using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public DialogueData_SO dialogueEmpty;

    public DialogueData_SO dialogueFinish;

    public DialogueData_SO dialogueFinishWater;

    public DialogueData_SO dialogueFinishFood;

    private Stack<string> dialogueEmptyStack;

    private Stack<string> dialogueFinishStack;

    private Stack<string> dialogueFinishWaterStack;

    private Stack<string> dialogueFinishFoodStack;

    private bool isTalking;



    private void Awake()
    {
        FillDialogueStack();
    }

    private void FillDialogueStack()
    {
        dialogueEmptyStack = new Stack<string>();
        dialogueFinishStack = new Stack<string>();
        dialogueFinishWaterStack = new Stack<string>();
        dialogueFinishFoodStack = new Stack<string>();

        for (int i = dialogueEmpty.dialogueList.Count - 1; i > -1; i--)
        {
            dialogueEmptyStack.Push(dialogueEmpty.dialogueList[i]);

        }
        for (int i = dialogueFinish.dialogueList.Count - 1; i > -1; i--)
        {
            dialogueFinishStack.Push(dialogueFinish.dialogueList[i]);
        }
        for (int i = dialogueFinishWater.dialogueList.Count - 1; i > -1; i--)
        {
            dialogueFinishWaterStack.Push(dialogueFinishWater.dialogueList[i]);

        }
        for (int i = dialogueFinishFood.dialogueList.Count - 1; i > -1; i--)
        {
            dialogueFinishFoodStack.Push(dialogueFinishFood.dialogueList[i]);
        }
    }

    public void ShowDialogueEmpty()
    {
        if (!isTalking)
            StartCoroutine(DialogueRoutine(dialogueEmptyStack));
    }

    public void ShowDialogueFinish()
    {
        if (!isTalking)
            StartCoroutine(DialogueRoutine(dialogueFinishStack));
    }
    public void ShowdialogueFinishWater()
    {
        if (!isTalking)
            StartCoroutine(DialogueRoutine(dialogueFinishWaterStack));
    }
    public void ShowdialogueFinishFood()
    {
        if (!isTalking)
            StartCoroutine(DialogueRoutine(dialogueFinishFoodStack));
    }
    private IEnumerator DialogueRoutine(Stack<string> data)
    {
        isTalking = true;
        if (data.TryPop(out string result))
        {
            EventHandler.CallShowDialogueEvent(result);
            yield return null;
            isTalking = false;
            EventHandler.CallGameStateChangeEvent(GameState.Pause);
        }
        else
        {
            EventHandler.CallShowDialogueEvent(string.Empty);
            FillDialogueStack();
            isTalking = false;
            EventHandler.CallGameStateChangeEvent(GameState.GamePlay);
        }
    }
}
