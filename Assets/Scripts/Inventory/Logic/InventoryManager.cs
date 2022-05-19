using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public ItemDataList_SO itemData;
    [SerializeField]List<ItemName> itemList=new List<ItemName>();

    private void OnEnable() {
        EventHandler.ItemUsedEvent += OnItemUsedEvent;
    }

    private void OnDisable() {
        EventHandler.ItemUsedEvent -= OnItemUsedEvent;
    }

    public void addItem(ItemName item)
    {
        if(!itemList.Contains(item))
        {
            itemList.Add(item);
            EventHandler.CallUpdateUIEvent(itemData.GetItemDetail(item),itemList.Count-1);
        }
        
    }

    public ItemDetails findItem(int index)
    {
        return itemData.GetItemDetail(itemList[index]);
    }

    public ItemDetails findItemByName(ItemName itemName)
    {
        return itemData.GetItemDetail(itemName);
    }

    public int findItemIndex(ItemName itemName)
    {
        for(int i=0;i<itemList.Count-1;i++)
        {
            if(itemList[i] == itemName)return i;
        }
        return -1;
    }
    
    public int itemcount()
    {
        return itemList.Count;
    }
    private void OnItemUsedEvent(ItemName item)
    {
        itemList.Remove(item);
        //todo:多个物体
        if(itemList.Count == 0)
           EventHandler.CallUpdateUIEvent(null,-1);
        else{
            EventHandler.CallUpdateUIEvent(findItem(0),0);
        }
    }

}
