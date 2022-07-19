using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Dictionary<string,bool> miniGameStateDict= new Dictionary<string,bool>();
    private void OnEnable() {
        EventHandler.AfterSceneLoadEvent += OnAfterSceneLoadEvent;
        EventHandler.MiniGamePassEvent += OnMiniGamePassEvent;

    }
    private void OnDisable() {
        EventHandler.AfterSceneLoadEvent -= OnAfterSceneLoadEvent;
        EventHandler.MiniGamePassEvent -= OnMiniGamePassEvent;
        
    }
    void Start()
    {
    //    SceneManager.LoadScene("Menu",LoadSceneMode.Additive);
       EventHandler.CallGameStatusChangeEvent(GameStatus.GamePlay);
    }

    void OnAfterSceneLoadEvent(){
        foreach(var miniGame in FindObjectsOfType<MiniGame>()){
            if(miniGameStateDict.TryGetValue(miniGame.gameName,out bool isPass)){
                miniGame.isPass = isPass;
                miniGame.UpdateMiniGameState();
            }
        }
    }

    void OnMiniGamePassEvent(string gameName){
        Debug.Log("minigamepass");
        this.miniGameStateDict[gameName] = true;
    }
}
