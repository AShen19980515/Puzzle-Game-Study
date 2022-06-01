using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oldwoman : Interactive
{
    private DialogController dialogController;
    
    private void Awake(){
        dialogController =  GetComponent<DialogController>();
    }

    public override void EmptyClicked()
    {
        if(!isDone)
        dialogController.showDialogueEmpty();
        else{
            dialogController.showDialogueFinish();
        }
    }

    protected override void OnClickedAction()
    {
        dialogController.showDialogueFinish();
    }
}
