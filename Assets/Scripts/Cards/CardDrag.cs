using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform cardParent = null;
    private CanvasGroup canvasGroup;
    private Vector3 originalPosition;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = transform.localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        cardParent = transform.parent;
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Card Drag");
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        Debug.Log("Card Dropped");
        canvasGroup.blocksRaycasts = true;

        Discard discardCard = eventData.pointerEnter?.GetComponent<Discard>();
        if (discardCard != null)
        {
            discardCard.OnDrop(eventData);
        }
        else
        {
            ReturnToOriginalPosition();
        }
    }

    private void ReturnToOriginalPosition()
    {
        transform.SetParent(cardParent);
        transform.DOMove(originalPosition, 0.3f);
    }
}