using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;
    public SlotUI slotUI;
    public GameObject itemtitle;
    public Text text;
    private int itemIndex=-1;

    private void OnEnable() {
        EventHandler.UpdateUIEvent +=OnUpdateUIEvent;
    }
    private void OnDisable() {
        EventHandler.UpdateUIEvent -=OnUpdateUIEvent;
    }

    private void OnUpdateUIEvent(ItemDetails itemDetails, int index)
    {
        if(itemDetails == null)
        {
            itemIndex=-1;
            slotUI.setEmpty();
            itemtitle.SetActive(false);
            text.text="";
            leftButton.interactable=false;
            rightButton.interactable=false;
        }else{
            itemIndex=index;
            slotUI.setItem(itemDetails);
            itemtitle.SetActive(true);
            text.text=itemDetails.itemtitle;
        }
    }
}
