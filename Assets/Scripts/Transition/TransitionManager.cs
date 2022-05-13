using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    public CanvasGroup fadecanvas;
    public float fadeDuration=2;
    bool isfade=false;
    
    public void Transition(string from,string to)
    {
        if(!isfade)
        StartCoroutine(TransitionToScene(from,to)); 
    }

    IEnumerator TransitionToScene(string from,string to)
    {
        yield return Fade(1);
        yield return SceneManager.UnloadSceneAsync(from);
        yield return SceneManager.LoadSceneAsync(to,LoadSceneMode.Additive);

        Scene newScene=SceneManager.GetSceneAt(SceneManager.sceneCount-1);
        SceneManager.SetActiveScene(newScene);
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
        Debug.Log("开始fade");
        float speed=Mathf.Abs(fadecanvas.alpha-targetAlpha)/fadeDuration;
        while(!Mathf.Approximately(fadecanvas.alpha,targetAlpha)){
            fadecanvas.alpha=Mathf.MoveTowards(fadecanvas.alpha,targetAlpha,speed*Time.deltaTime);
            yield return null;
        }

        isfade=false;
        fadecanvas.blocksRaycasts=false;
    }
}
