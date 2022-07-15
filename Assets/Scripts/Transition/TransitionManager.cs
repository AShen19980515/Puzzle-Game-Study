using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    #region 变量
    public string startScene="H1";
    public CanvasGroup fadecanvas;
    public float fadeDuration=2;
    bool isfade=false;
    bool canTransition=true;
    #endregion
    private void OnEnable() {
        EventHandler.GameStatusChangeEvent += OnCallGameStatusChangeEvent;
    }

    private void OnDisable() {
        EventHandler.GameStatusChangeEvent -= OnCallGameStatusChangeEvent;
    }

    private void OnCallGameStatusChangeEvent(GameStatus gameStatus)
    {
        canTransition = gameStatus==GameStatus.GamePlay;
    }

    private void Start() {
        StartCoroutine(TransitionToScene(string.Empty,startScene)); 
    }
    
    public void Transition(string from,string to)
    {
        if(!isfade && canTransition)
        StartCoroutine(TransitionToScene(from,to)); 
    }

    IEnumerator TransitionToScene(string from,string to)
    {
        if(from != string.Empty)
        {
        yield return Fade(1);
        EventHandler.CallBeforeSceneUnloadEvent();
        yield return SceneManager.UnloadSceneAsync(from);
        }
        yield return SceneManager.LoadSceneAsync(to,LoadSceneMode.Additive);

        Scene newScene=SceneManager.GetSceneAt(SceneManager.sceneCount-1);
        SceneManager.SetActiveScene(newScene);

        EventHandler.CallAfterSceneLoadEvent();
        yield return Fade(0);
    }

/// <summary>
/// 场景淡入淡出
/// </summary>
/// <param name="targetAlpha">1是黑，0是透明</param>
/// <returns></returns>
    IEnumerator Fade(float targetAlpha)
    { 
        isfade=true;
        fadecanvas.blocksRaycasts=true;
        float speed=Mathf.Abs(fadecanvas.alpha-targetAlpha)/fadeDuration;
        while(!Mathf.Approximately(fadecanvas.alpha,targetAlpha)){
            fadecanvas.alpha=Mathf.MoveTowards(fadecanvas.alpha,targetAlpha,speed*Time.deltaTime);
            yield return null;
        }

        isfade=false;
        fadecanvas.blocksRaycasts=false;
    }
}
