using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void Revive()
    {
        if (PlayerPrefs.GetString("isGirl").Equals("Yes"))
        {
            SceneManager.LoadScene("Girl");
        } else if (PlayerPrefs.GetString("isGirl").Equals("No"))
        {
            SceneManager.LoadScene("Boy");

        }
    }

}
