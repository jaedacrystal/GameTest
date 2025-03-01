using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class DiscardCard : MonoBehaviour, CardDropArea
{
    public void OnCardDrop(CardDrag card)
    {
        card.gameObject.SetActive(false);
    }

    public void OnCardDropCard(DragCard draggedCard)
    {
        draggedCard.gameObject.SetActive(false);
    }
}