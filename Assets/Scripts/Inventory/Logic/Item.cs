using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemName itemName;

    public void ItemClicked()
    {
        this.gameObject.SetActive(false);
        InventoryManager.Single.addItem(itemName);
    }
}
