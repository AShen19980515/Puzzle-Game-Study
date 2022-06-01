using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotUI : MonoBehaviour,IPointerClickHandler
{
    public Image itemImage;
    public ItemTitle itemtitle;
    ItemDetails item;
    private bool isSelected;
    RectTransform rect;
    public Image itemcontent;
    private void Awake() {
        rect=this.gameObject.GetComponent<RectTransform>();
    }

    public void setItem(ItemDetails item)
    {
        this.item=item;
        this.gameObject.SetActive(true);
        itemImage.sprite=item.itemSprite;
        itemImage.SetNativeSize();
    }

    public void setEmpty()
    {
        this.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    { 
        isSelected=!isSelected;
        EventHandler.CallItemSelectedEvent(item,isSelected);

        if(isSelected)
        {
            rect.localScale=new Vector3(1.1f,1.1f,1.1f);
            itemtitle.gameObject.SetActive(true);
            itemtitle.UpdateItemName(item.itemName);

            if(item.itemContent){
            itemcontent.gameObject.SetActive(true);
            itemcontent.sprite=item.itemContent;
            itemcontent.SetNativeSize();
        }
            
        }else
        {
            rect.localScale=new Vector3(1.0f,1.0f,1.0f);
            itemtitle.gameObject.SetActive(false);

            if(item.itemContent){
                itemcontent.gameObject.SetActive(false);
            }
        }
    }
}
