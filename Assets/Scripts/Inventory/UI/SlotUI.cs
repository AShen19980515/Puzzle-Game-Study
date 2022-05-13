using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Image itemImage;
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
}
