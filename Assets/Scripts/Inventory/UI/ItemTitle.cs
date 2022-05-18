using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTitle : MonoBehaviour
{
    public Text itemTitle;

    public void UpdateItemName(ItemName itemName)
    {
        itemTitle.text=itemName switch
        {
            ItemName.key => InventoryManager.Single.findItemByName(itemName).itemtitle,
            ItemName.ticket=>InventoryManager.Single.findItemByName(itemName).itemtitle,
            _=>""
        };
    }
}
