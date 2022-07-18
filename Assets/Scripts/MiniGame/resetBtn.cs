using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetBtn : Interactive
{
    public override void EmptyClicked()
    {
        GameController.Single.ResetGame();
    }
}
