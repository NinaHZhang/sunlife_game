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
        currentHealth -= _damage
    }
    void Update()
    {
        
    }
}
