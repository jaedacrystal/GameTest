using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EmailLinkHandler : MonoBehaviour, IPointerClickHandler
{
    public GameObject hackedPopup;

    public void OnPointerClick(PointerEventData eventData)
    {
        var text = GetComponent<TextMeshProUGUI>();
        if (TMP_TextUtilities.FindIntersectingLink(text, eventData.position, eventData.pressEventCamera) != -1)
            hackedPopup.SetActive(true);
    }
}
