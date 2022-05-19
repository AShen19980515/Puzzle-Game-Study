using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mailBox : Interactive
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D coil;
    public Sprite openSprite;

    private void OnEnable() {
        EventHandler.AfterSceneLoadEvent += OnAfterSceneLoadEvent;
    }


    private void OnDisable() {
        EventHandler.AfterSceneLoadEvent -= OnAfterSceneLoadEvent;
    }
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        coil = GetComponent<BoxCollider2D>();
    }

    protected override void OnClickedAction()
    {
        base.OnClickedAction();
        spriteRenderer.sprite = openSprite;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnAfterSceneLoadEvent()
    {
        if(!isDone)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else{
            spriteRenderer.sprite =openSprite;
            coil.enabled=false;
        }
    }
}
