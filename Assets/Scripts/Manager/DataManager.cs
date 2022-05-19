using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    Dictionary<ItemName,bool> itemAvailableDict=new Dictionary<ItemName, bool>();
    Dictionary<string,bool> interactiveStateDict=new Dictionary<string, bool>();

    private void OnEnable() {
        EventHandler.AfterSceneLoadEvent += OnAfterSceneLoadEvent;
        EventHandler.BeforeSceneUnloadEvent += OnBeforeSceneUnloadEvent;
        EventHandler.UpdateUIEvent += OnUpdateUIEvenet;
    }

    private void OnDisable() {
        EventHandler.AfterSceneLoadEvent -= OnAfterSceneLoadEvent;
        EventHandler.BeforeSceneUnloadEvent -= OnBeforeSceneUnloadEvent;
        EventHandler.UpdateUIEvent -= OnUpdateUIEvenet;
    }

    private void OnBeforeSceneUnloadEvent()
    {
        foreach(var item in FindObjectsOfType<Item>())
        {
            if(!itemAvailableDict.ContainsKey(item.itemName))
                itemAvailableDict.Add(item.itemName,true);
        }

        foreach(var item in FindObjectsOfType<Interactive>())
        {
            if(interactiveStateDict.ContainsKey(item.name))
              interactiveStateDict[item.name] = item.isDone;
              else interactiveStateDict.Add(item.name, item.isDone);
        }
    }

    private void OnAfterSceneLoadEvent()
    {
        //如果已经在字典中则更新状态，不在则添加
        foreach(var item in FindObjectsOfType<Item>())
        {
            if(!itemAvailableDict.ContainsKey(item.itemName))
                itemAvailableDict.Add(item.itemName,true);
            else item.gameObject.SetActive(itemAvailableDict[item.itemName]);
        }

        foreach(var item in FindObjectsOfType<Interactive>())
        {
            if(interactiveStateDict.ContainsKey(item.name))
              item.isDone = interactiveStateDict[item.name];
              else interactiveStateDict.Add(item.name, item.isDone);
        }
    }

    private void OnUpdateUIEvenet(ItemDetails itemDetails,int arg)
    {
        if(itemDetails !=null)itemAvailableDict[itemDetails.itemName]=false;
    }
}
