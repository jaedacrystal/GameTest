using UnityEngine;
using DG.Tweening;

public class ScaleOnHover : MonoBehaviour
{
    [SerializeField] private float scaleIncrease;
    [SerializeField] private float popupTime;

    private Vector3 initialScale;

    private void OnMouseEnter()
    {
        IncreaseScale(true);
    }
    private void OnMouseExit()
    {
        IncreaseScale(false);
    }
    
    private void Awake()
    {
        initialScale = transform.localScale;
    }

    private void IncreaseScale(bool status)
    {
        Vector3 finalScale = initialScale;

        if (status)
            finalScale = initialScale * scaleIncrease;
            transform.DOScale(finalScale, popupTime);
    }
}