using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
 
    public float speed = 5f;
    public bool isFacingLeft;

    // Update is called once per frame
    void Update()
    {

        if (isFacingLeft == true)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (isFacingLeft == false)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

}
