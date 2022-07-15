using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public UnityEvent OnFinsh;

    public DataH2A_SO gameData;
    public GameObject lineParent;
    public LineRenderer linePrefab;
    public Ball ballPrefab;

    public Transform[] holderTransforms;


    private void Awake() {
        DrawLines();
        CreateBall();
    }

    private void OnEnable() {
        EventHandler.MiniGameStateEvent += OnMiniGameStateEvent;
    }

    private void OnDisable() {
        EventHandler.MiniGameStateEvent -= OnMiniGameStateEvent;
    }
    public void DrawLines(){
        foreach(var connection in gameData.lineConnections)
        {
            var line = Instantiate(linePrefab,lineParent.transform);
            line.SetPosition(0,holderTransforms[connection.from].position);
            line.SetPosition(1,holderTransforms[connection.to].position);

            //添加连接关系
            holderTransforms[connection.from].GetComponent<Holder>().linkHolders.Add(holderTransforms[connection.to].GetComponent<Holder>());
            holderTransforms[connection.to].GetComponent<Holder>().linkHolders.Add(holderTransforms[connection.from].GetComponent<Holder>());

        }
    }

    public void CreateBall()
    {
        for(int i = 0;i < gameData.startBallOrder.Count;i++)
        {
            if(gameData.startBallOrder[i] == BallName.None)
            {
                holderTransforms[i].GetComponent<Holder>().isEmpty = true;
                continue;
            }
            Ball ball = Instantiate(ballPrefab,holderTransforms[i]);
            holderTransforms[i].GetComponent<Holder>().isEmpty = false;
            ball.SetBall(gameData.GetBallDetails(gameData.startBallOrder[i]));

            //检查球是否匹配
            holderTransforms[i].GetComponent<Holder>().CheckBall(ball);
        }
    }

    private void OnMiniGameStateEvent(){
        foreach(var ball in FindObjectsOfType<Ball>())
        {
            if(!ball.isMatch)return;
        }
        Debug.Log("游戏结束");
        OnFinsh?.Invoke();
    }
}
