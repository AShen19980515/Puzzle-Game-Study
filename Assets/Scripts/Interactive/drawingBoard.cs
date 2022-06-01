using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawingBoard : Interactive
{
    public Camera LookCamera;
    bool islooked=false;
    protected override void OnClickedAction()
    {
        base.OnClickedAction();
    }
    public override void EmptyClicked()
    {
        CameraManager.Single.CameraLook(transform,islooked);
        islooked=!islooked;
    }
}
