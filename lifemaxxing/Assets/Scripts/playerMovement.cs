using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 128f;

    private Animator playerAnimation;

    public GameObject bullet;
    public float bulletSpeed = 1f;

    public bool isFacingLeft = false;
    public bool isFacingDown = false;
    public bool isFacingUp = false;
    public CoinManager cm;
    public int playerHealth = 3;
    public SpriteRenderer playerRenderer;


    private void Start()
    {
        playerAnimation = this.gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        //standing
        transform.position = new Vector3(transform.position.x + Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, transform.position.y + Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0);
        if (Input.GetAxisRaw("Vertical") == 0f && Input.GetAxisRaw("Horizontal") == 0f)
        {
            playerAnimation.SetBool("isWalk", false);
           

        } //runnning
        else
        {
            playerAnimation.SetBool("isWalk", true);

            if (Input.GetAxisRaw("Horizontal") <= -1f)

            {

                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                isFacingLeft = true;
                isFacingDown = false;
                isFacingUp = false;
            }
            if (Input.GetAxisRaw("Horizontal") >= 1f)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                isFacingLeft = false;
                isFacingDown = false;
                isFacingUp = false;
            }

            if (Input.GetAxisRaw("Vertical") <= -1f)
            {
                isFacingLeft = false;
                isFacingDown = true;
                isFacingUp = false;
            }
            if (Input.GetAxisRaw("Vertical") >= 1f)
            {
                isFacingDown = false;
                isFacingLeft = false;
                isFacingUp = true;
            }
            
        }

        if (isFacingLeft)
        {
            if (Input.GetKeyDown("space"))
            {
                ShootBulletLeft();
            }
        }

        if (isFacingDown)
        {
            if (Input.GetKeyDown("space"))
            {
                ShootBulletDown();
            }
        }
        if (!isFacingDown && !isFacingLeft &&!isFacingUp)
        {
            if (Input.GetKeyDown("space"))
            {
                ShootBulletRight();
            }
        }
        if (isFacingUp)
        {
            if (Input.GetKeyDown("space"))
            {
                ShootBulletUp();
            }
        }


    }

    private void ShootBulletLeft()
    {
        GameObject newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
        newBullet.GetComponent<bullet>().isFacingLeft = true;
        newBullet.GetComponent<bullet>().isFacingDown = false;
        newBullet.GetComponent<bullet>().isFacingUp = false;
    }

    private void ShootBulletRight()
    {
        GameObject newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
        newBullet.GetComponent<bullet>().isFacingLeft = false;
        newBullet.GetComponent<bullet>().isFacingDown = false;
        newBullet.GetComponent<bullet>().isFacingUp = false;

    }

    private void ShootBulletDown()
    {
        GameObject newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
        newBullet.GetComponent<bullet>().isFacingLeft = false;
        newBullet.GetComponent<bullet>().isFacingDown = true;
        newBullet.GetComponent<bullet>().isFacingUp = false;

    }


    private void ShootBulletUp()
    {
        GameObject newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
        newBullet.GetComponent<bullet>().isFacingLeft = false;
        newBullet.GetComponent<bullet>().isFacingDown = false;
        newBullet.GetComponent<bullet>().isFacingUp = true;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            cm.coinCount++;
        }

        if (other.gameObject.CompareTag("enemy"))
        {
            playerHealth--;
            playerRenderer.color = new Color(1, 0, 0, 1);
        }

       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            playerRenderer.color = Color.white;
        }

    }

}