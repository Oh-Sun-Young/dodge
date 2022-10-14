using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MultiJoy : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform pad;
    public RectTransform stick;
    public void OnDrag(PointerEventData eventData)
    {
        if (!eventData.IsPointerMoving() || eventData.pointerDrag == null) return;
        else
        {
            stick.position = eventData.position;
            stick.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.5f);
            FindObjectOfType<PlayerController>().GetComponent<PlayerController>().xBtn = stick.localPosition.x * 0.01f;
            FindObjectOfType<PlayerController>().GetComponent<PlayerController>().zBtn = stick.localPosition.y * 0.01f;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pad.position = new Vector3(eventData.position.x , eventData.position.y, 0);
        pad.gameObject.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        stick.localPosition = Vector2.zero;
        pad.gameObject.SetActive(false);
        FindObjectOfType<PlayerController>().GetComponent<PlayerController>().xBtn = 0;
        FindObjectOfType<PlayerController>().GetComponent<PlayerController>().zBtn = 0;
    }

    void Update()
    {
        if (!Data.isGame)
        {
            pad.position = Vector2.zero;
            stick.position = Vector2.zero;
            pad.gameObject.SetActive(false);
        }
    }
}
