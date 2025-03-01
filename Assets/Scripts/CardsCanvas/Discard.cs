using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Discard : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        CardDrag card = eventData.pointerDrag.GetComponent<CardDrag>();
        if (card != null)
        {
            CardManager cardManager = FindObjectOfType<CardManager>();
            if (cardManager != null)
            {
                cardManager.RemoveCard(card.gameObject);
            }
            card.gameObject.SetActive(false);
        }
    }
}
