using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
<<<<<<< HEAD
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);

        
        if (currentHealth > 0) {
            //player hurt
        }
        else {
            //player dead 
        }
=======
>>>>>>> d1ecd5bf15e765b62eed127610625096f749ce02
    }
    void Update()
    {
        //i just substituted damage with E key
        if (Input.GetKeyDown(KeyCode.E)){
            TakeDamage(1);
        }
    }
}
