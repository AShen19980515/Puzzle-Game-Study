using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotUI : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    public Image itemImage;
    public ItemTitle itemtitle;
    ItemDetails item;
    private bool isSelected;

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
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(this.gameObject.activeInHierarchy)
        {
            itemtitle.gameObject.SetActive(true);
            itemtitle.UpdateItemName(item.itemName);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        itemtitle.gameObject.SetActive(false);
    }
}
