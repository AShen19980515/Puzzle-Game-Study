using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    public Camera mainCamera;
    public Camera lookCamera;
    public void CameraLook(Transform lookpoint,bool islooked)
    {
        if(!islooked)
        {
          lookCamera.depth=mainCamera.depth+1;
          lookCamera.transform.LookAt(lookpoint);
          lookCamera.fieldOfView = 20f;
        }else{
          lookCamera.depth=mainCamera.depth-1;
        }
    }
}
