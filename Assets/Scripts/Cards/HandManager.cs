using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Splines;

public class HandManager : MonoBehaviour
{
    [SerializeField] private int maxHandSize;
    [SerializeField] private GameObject card;
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] private Transform spawnPoint;

    private List<GameObject> handCards = new();

    public void DrawCards()
    {
        if (handCards.Count >= maxHandSize) return;
        GameObject g = Instantiate(card, spawnPoint.position, spawnPoint.rotation);
        handCards.Add(g);
        UpdateCardPos();
    }

    public void UpdateCardPos()
    {
        if (handCards.Count == 0) return;
        float cardSpacing = 1f / maxHandSize;
        float firstCardPos = 0.5f - (handCards.Count - 1) * cardSpacing / 2;
        Spline spline = splineContainer.Spline;

        for (int i = 0; i < handCards.Count; i++)
        {
            float pos = firstCardPos + i * cardSpacing;
            Vector3 splinePosition = spline.EvaluatePosition(pos);
            Vector3 forward = spline.EvaluateTangent(pos);
            Vector3 up = spline.EvaluateUpVector(pos);

            Quaternion rotation = Quaternion.LookRotation(up, Vector3.Cross(up, forward).normalized);

            handCards[i].transform.DOMove(splinePosition, 0.4f);
            handCards[i].transform.DOLocalRotateQuaternion(rotation, 0.25f);
        }
    }
}
