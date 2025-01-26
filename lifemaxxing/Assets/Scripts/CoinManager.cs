using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public int levelTime;
    public Text text;
    public GameObject endingCanvasScreen;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = levelTime;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Time Remaining: " + levelTime;
        time -= Time.deltaTime;
        levelTime = (int)time;

        if (levelTime <= 0)
        {
            endingCanvasScreen.SetActive(true);
        }
    }
}
