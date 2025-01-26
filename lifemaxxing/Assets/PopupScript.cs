using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPanel; // Assign your popup panel in the inspector
    public Button openButton;
    public Button closeButton;

    void Start()
    {
        popupPanel.SetActive(false); // Hide popup initially

        openButton.onClick.AddListener(OpenPopup);
        closeButton.onClick.AddListener(ClosePopup);
    }

    void OpenPopup()
    {
        popupPanel.SetActive(true);
    }

    void ClosePopup()
    {
        popupPanel.SetActive(false);
    }
}
