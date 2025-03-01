using System.Collections;
using System.Collections.Generic;
using TMPro;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using DG.Tweening;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour
{
    [SerializeField] GameObject cardPrefab;
    [SerializeField] GameObject hand;
    [SerializeField] private int maxHandSize;

    public List<GameObject> card = new();

    private void Start()
    {
        cardPrefab.transform.SetParent(hand.transform, false);
    }

    public void DrawCard()
    {
        if (card.Count >= maxHandSize) return;
        GameObject g = Spawn();
        g.transform.localScale = Vector3.zero;
        g.transform.DOScale(Vector3.one, 0.3f);
        card.Add(g);
        CardPosition();
    }

    public GameObject Spawn()
    {
        return Instantiate(cardPrefab, transform);
    }

    public void CardPosition()
    {
        if (card.Count == 0) return;
        for (int i = 0; i < maxHandSize; i++)
        {
            float center = (card.Count - 1) / 2f;
            float interval = 100f;
            float x = (i - center) * interval;

            card[i].transform.localPosition= new Vector3(x, 0, 0);
        }
    }

    public void RemoveCard(GameObject cardToRemove)
    {
        if (card.Contains(cardToRemove))
        {
            card.Remove(cardToRemove);
            CardPosition();
        }
    }
}
