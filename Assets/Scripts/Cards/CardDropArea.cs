using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CardDropArea
{
    void OnCardDrop(CardDrag card);
    void OnCardDropCard(DragCard draggedCard);
}
