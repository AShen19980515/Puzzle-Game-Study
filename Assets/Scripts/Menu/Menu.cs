using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void QuitGame(){
        Application.Quit();
    }

    public void ResumeGame(){
        Debug.Log("继续游戏");
        //todo:保存状态
    }

    public void BackToMenu(){
        var curScene = SceneManager.GetActiveScene().name;
        TransitionManager.Single.Transition(curScene,"Menu");
    }
}
