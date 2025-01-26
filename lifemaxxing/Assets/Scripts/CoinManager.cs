using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public TMP_Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins Collected: " + coinCount.ToString();
    }
}
