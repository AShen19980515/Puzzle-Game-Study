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
            //itemtitle.SetActive(true);
            //text.text=itemDetails.itemtitle;
            if(itemIndex==0 && InventoryManager.Single.itemcount()>1){
                leftButton.interactable=false;
                rightButton.interactable=true;
            }
            else if(itemIndex==InventoryManager.Single.itemcount()-1 && itemIndex!=0)
            {
                leftButton.interactable=true;
                rightButton.interactable=false;
            }
            else if(InventoryManager.Single.itemcount()>1){
                leftButton.interactable=true;
                rightButton.interactable=true;
            }
        }
    }

    public void leftButtonClick()
    {
        ItemDetails item=null;
        if(itemIndex>0)
        {
         EventHandler.CallUpdateUIEvent(InventoryManager.Single.findItem(--itemIndex),itemIndex);
        }
    }

    public void rightButtonClick()
    {
        ItemDetails item=null;
        if(itemIndex<InventoryManager.Single.itemcount()-1)
        {
         EventHandler.CallUpdateUIEvent(InventoryManager.Single.findItem(++itemIndex),itemIndex);
        }
    }
}
