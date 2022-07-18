using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DataH2A_SO",menuName ="MiniGameData/DataH2A_SO")]
public class DataH2A_SO : ScriptableObject
{
    public string gameName;
    [Header("球的名字和对应的图片")]
    public List<BallDetails> ballList;
    
    [Header("逻辑数据")]
    public List<Connections> lineConnections;
    public List<BallName> startBallOrder;
    
    public BallDetails GetBallDetails(BallName ballName)
    {
        return ballList.Find(b => b.ballName == ballName);
    }
}

[System.Serializable]
public class BallDetails
{
    public BallName ballName;
    public Sprite wrongSprite;
    public Sprite rightSprite;
}

[System.Serializable]
public class Connections
{
    public int from;
    public int to;
}
