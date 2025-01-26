using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame

    public void TakeDamage(float _damage) {
        currentHealth -= _damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);

        
        if (currentHealth > 0) {
            //player hurt
        }
        else {
            //player dead
            SceneManager.LoadScene("GameOver");

        }
    }
    void Update()
    {

    }
}
