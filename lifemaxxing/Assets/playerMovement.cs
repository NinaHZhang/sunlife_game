using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 128f;
    public Transform movePoint;

    private Animator playerAnimation;

    public CoinManager cm;

    private void Start()
    {
        movePoint.parent = null;
        playerAnimation = this.gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, transform.position.y + Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0);
        if (Input.GetAxisRaw("Vertical") == 0f && Input.GetAxisRaw("Horizontal") == 0f)
        {
            playerAnimation.SetBool("isWalk", false);
            if(Input.GetAxisRaw("Vertical") >= 1f || Input.GetAxisRaw("Horizontal") >= -1f)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            if(Input.GetAxisRaw("Vertical") >= -1f || Input.GetAxisRaw("Horizontal") >= 1f)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }

        }
        else
        {
            playerAnimation.SetBool("isWalk", true);
        }

       

    }
    
     

     
     void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("coin")) {
            cm.coinCount ++;
        }
     }
}