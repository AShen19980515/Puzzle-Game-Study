using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    Dictionary<ItemName,bool> itemAvailableDict=new Dictionary<ItemName, bool>();

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
    }

    private void OnUpdateUIEvenet(ItemDetails itemDetails,int arg)
    {
        if(itemDetails !=null)itemAvailableDict[itemDetails.itemName]=false;
    }
}
