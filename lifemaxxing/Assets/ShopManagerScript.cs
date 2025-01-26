using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ShopManagerScript : MonoBehaviour
{
    public int[,] shopItems = new int[4, 4];
    public string[,] insuranceTypes = new string[4, 4];
    public float coins;
    public TextMeshProUGUI CoinsTxt;

    // Reference to the popup and its text
    public GameObject popupCanvas;  // The popup UI (with Image and Text)
    public TextMeshProUGUI popupText;  // The message to display in the popup
    public Button confirmButton;  // The button to confirm the purchase
    public Button cancelButton;  // The button to cancel the purchase

    private int currentItemID = -1;

    void Start()
    {
        // Make sure the popup is hidden initially
        popupCanvas.SetActive(false);  // Hide the popup when the scene starts
        CoinsTxt.text = "Coins: " + coins.ToString();

        // Initialize shopItems and insuranceTypes
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
        shopItems[2, 4] = 40;

        insuranceTypes[1, 1] = "Home Insurance";
        insuranceTypes[1, 2] = "Health Insurance";
        insuranceTypes[1, 3] = "Life Insurance";
        insuranceTypes[1, 4] = "Disability Insurance";
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        currentItemID = ButtonRef.GetComponent<ButtonInfo>().ItemID;  // Get the ItemID of the button clicked

        // Check if you have enough coins
        if (coins >= shopItems[2, currentItemID])
        {
            // Show the popup and change the text based on the ItemID
            popupCanvas.SetActive(true);

            // Set different text for each button ID
            switch (currentItemID)
            {
                case 1:
                    popupText.text = "Grants you an additional heart.";
                    break;
                case 2:
                    popupText.text = "Reduces house shield cool down period.";
                    break;
                case 3:
                    popupText.text = "Refills your hearts once after losing in a game.";
                    break;
                case 4:
                    popupText.text = "Stops the effects of any mobs with long-lasting effects.";
                    break;
                default:
                    popupText.text = "Unknown item.";
                    break;
            }

            // Set up button listeners for the popup
            confirmButton.onClick.RemoveAllListeners();
            confirmButton.onClick.AddListener(ConfirmPurchase);

            cancelButton.onClick.RemoveAllListeners();
            cancelButton.onClick.AddListener(ClosePopup);
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }

    // Method to confirm purchase
    void ConfirmPurchase()
    {
        coins -= 100;
        shopItems[3, currentItemID]++;
        CoinsTxt.text = "Coins: " + coins.ToString();

        ClosePopup();  // Close the popup after confirming; switch scenes 
    }

    // Method to close the popup
    void ClosePopup()
    {
        popupCanvas.SetActive(false);
    }
}
