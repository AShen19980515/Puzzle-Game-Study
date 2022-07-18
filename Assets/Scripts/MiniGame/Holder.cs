using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : Interactive
{
    public HashSet<Holder> linkHolders = new HashSet<Holder>();
    public bool isEmpty;
    public BallName matchBall;
    public Ball currentBall;

    public void CheckBall(Ball ball)
    {
        currentBall = ball;
        if (currentBall.ballDetails.ballName == matchBall)
        {
            currentBall.isMatch = true;
            currentBall.SetRight();
        }
        else
        {
            currentBall.isMatch = false;
            currentBall.SetWrong();
        }
    }
    public override void EmptyClicked()
    {
        foreach(var holder in linkHolders)
        {
            if(holder.isEmpty){
                //移动球
                currentBall.transform.position = holder.transform.position;
                currentBall.transform.SetParent(holder.transform);

                //检查球
                holder.CheckBall(currentBall);
                this.currentBall = null;

                this.isEmpty = true;
                holder.isEmpty = false;
                EventHandler.CallMiniGameStateEvent();
            }
        }
    }
}
