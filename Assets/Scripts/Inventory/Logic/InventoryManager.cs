using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public ItemDataList_SO itemData;
    [SerializeField]List<ItemName> itemList=new List<ItemName>();

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
    
    public int itemcount()
    {
        return itemList.Count;
    }
}
