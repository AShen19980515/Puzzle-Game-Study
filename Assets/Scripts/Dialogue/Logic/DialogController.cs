using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    public DialogueData_SO dialogueEmpty;
    public DialogueData_SO dialogueFinish;

    private Stack<string> dialogueEmptyStack;
    private Stack<string> dialogueFinishStack;
    private bool isTalking;

    private void Awake() {
        FillDialogueStack();
    }
    private void FillDialogueStack()
    {
        dialogueEmptyStack = new Stack<string>();
        dialogueFinishStack = new Stack<string>();

        for(int i=dialogueEmpty.dialogueList.Count-1;i>-1;i--)
        {
            dialogueEmptyStack.Push(dialogueEmpty.dialogueList[i]);
        }
        for(int i=dialogueFinish.dialogueList.Count-1;i>-1;i--)
        {
            dialogueFinishStack.Push(dialogueFinish.dialogueList[i]);
        }
    }

    public void showDialogueEmpty()
    {
        if(!isTalking)
        StartCoroutine(DialogRoutine(dialogueEmptyStack));
    }

    public void showDialogueFinish()
    {
        if(!isTalking)
        StartCoroutine(DialogRoutine(dialogueFinishStack));
    }

    private IEnumerator DialogRoutine(Stack<string> data)
    {
        isTalking=true;
        string result=string.Empty;
        if(data.Count>0){
            result=data.Pop();
            EventHandler.CallShowDialogEvent(result);
            yield return null;
            isTalking=false;
            EventHandler.CallGameStatusChangeEvent(GameStatus.Pause);
        }else{
            EventHandler.CallShowDialogEvent(string.Empty);
            yield return null;
            FillDialogueStack();
            isTalking=false;
            EventHandler.CallGameStatusChangeEvent(GameStatus.GamePlay);
        }
        
    }
}
