using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventHandler
{
    public static event Action<ItemDetails,int> UpdateUIEvent;

    public static void CallUpdateUIEvent(ItemDetails itemDetails,int index)
    {
        UpdateUIEvent?.Invoke(itemDetails,index);
    }

    public static event Action BeforeSceneUnloadEvent;

    public static void CallBeforeSceneUnloadEvent()
    {
        BeforeSceneUnloadEvent?.Invoke();
    }

    public static event Action AfterSceneLoadEvent;

    public static void CallAfterSceneLoadEvent()
    {
        AfterSceneLoadEvent?.Invoke();
    }

    public static event Action<ItemDetails,bool> ItemSelectedEvent;

    public static void CallItemSelectedEvent(ItemDetails item,bool isSelected)
    {
        ItemSelectedEvent?.Invoke(item,isSelected);
    }

    public static event Action<ItemName> ItemUsedEvent;

    public static void CallItemUsedEvent(ItemName itemName)
    {
        ItemUsedEvent?.Invoke(itemName);
    }

    public static event Action<string> ShowDialogEvent;

    public static void CallShowDialogEvent(string dialogText)
    {
        ShowDialogEvent?.Invoke(dialogText);
    }

    public static event Action<GameStatus> GameStatusChangeEvent;

    public static void CallGameStatusChangeEvent(GameStatus status)
    {
        GameStatusChangeEvent?.Invoke(status);
    }

    public static event Action MiniGameStateEvent;
    
    public static void CallMiniGameStateEvent()
    {
        MiniGameStateEvent?.Invoke();
    }
}
