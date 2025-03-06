using TMPro;
using UnityEngine;

public class EmailOpen : MonoBehaviour
{
    public GameObject emailPanel;
    public TextMeshProUGUI tmpText;



    public void OpenEmailPanel()
    {
        emailPanel.SetActive(true);
    }
}
