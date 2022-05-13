using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public string SceneFrom;
    public string SceneTo;
    public void TeleportToScene()
    {
        TransitionManager.Single.Transition(SceneFrom,SceneTo);
    }
}
