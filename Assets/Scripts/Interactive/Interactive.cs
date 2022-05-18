using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public ItemName requireItem;
    public bool isDone;

    public void CheckItem(ItemName itemName)
    {
        if(itemName == requireItem && !isDone)
        {
            isDone = true;
            OnClickedAction();
        }
    }
/// <summary>
/// 默认是正确的物品的情况执行
/// </summary>
    protected virtual void OnClickedAction()
    {
        Debug.Log("正确物品");
    }

    public virtual void EmptyClicked()
    {
        Debug.Log("空点");
    }
}
