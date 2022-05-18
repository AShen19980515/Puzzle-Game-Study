using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public RectTransform hand;
    private Vector3 mouseWorldPos =>Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0));
    
    private ItemName currentItem;
    
    private bool canclick;

    private bool holdItem;

    private void OnEnable() {
        EventHandler.ItemSelectedEvent += OnItemSelectedEvent;
    }

    private void OnDisable() {
        EventHandler.ItemSelectedEvent -= OnItemSelectedEvent;
    }

    private void OnItemSelectedEvent(ItemDetails itemDetails, bool isSelected)
    {
        Debug.Log("选取了");
        holdItem = isSelected;
        if(isSelected)
        {
            currentItem = itemDetails.itemName;
        }
        hand.gameObject.SetActive(holdItem);
    }

    private void Update() {
        canclick=ObjectAtMousePosition();

        if(hand.gameObject.activeInHierarchy)
        {
            hand.position=Input.mousePosition;
        }
        if(canclick && Input.GetMouseButtonDown(0))
        {
            ClickAction(ObjectAtMousePosition().gameObject);
        }
    }

    private void ClickAction(GameObject obj)
    {
        switch(obj.tag)
        {
            case "Teleport":
            var Teleport=obj.GetComponent<Teleport>();
            Teleport.TeleportToScene();
            break;
            case "Item":
            var Item=obj.GetComponent<Item>();
            Item.ItemClicked();
            break;
            case "Interactive":
            var Interactive=obj.GetComponent<Interactive>();
            if(holdItem)
               Interactive?.CheckItem(currentItem);
            else
               Interactive?.EmptyClicked();
            break;
            default:break;
        }
    }
    private Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }
}
