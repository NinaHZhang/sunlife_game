using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 5;

    public Transform player;  // Reference to the player's Transform
    public float moveSpeed = 2.0f; // Speed of movement

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
                Destroy(this.gameObject);

            
        }

        if (player != null)
        {
                // Calculate the direction to the player
                Vector3 direction = (player.position - transform.position).normalized;

                // Move the object towards the player
                transform.position += direction * moveSpeed * Time.deltaTime;
        }

    }

    public void gotHit()
    {
        health--;
    }


}
