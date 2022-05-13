using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private Vector3 mouseWorldPos =>Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0));
    private bool canclick;

    
    private void Update() {
        canclick=ObjectAtMousePosition();

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
            default:break;
        }
    }
    private Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }
}
