using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public TextMeshProUGUI PriceTxt;
    public TextMeshProUGUI InsuranceTxt;
    public GameObject ShopManager;
    
    void Update()
    {
        PriceTxt.text = "Price: $100";
        InsuranceTxt.text = ShopManager.GetComponent<ShopManagerScript>().insuranceTypes[4, ItemID];
    }
}
