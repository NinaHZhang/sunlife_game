using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public SpriteRenderer playerRenderer;
    public health hearts;
    private bool shielded; 
    public GameObject shield;
    public Image image;

  

    


    private void Start()
    {
        playerAnimation = this.gameObject.GetComponent<Animator>();
        shielded = false;
      
        
        
    }
    // Update is called once per frame

    void NoShield(){
            shield.SetActive(false);
            shielded = false;
        }
    IEnumerator CheckShield(){
          
            if (Input.GetKeyDown(KeyCode.H) && !shielded && image.enabled)
            {
                shield.SetActive(true);
                shielded = true;
                //code for turning off shield after 3 seconds
                yield return new WaitForSeconds(5);

                NoShield();
            }
     
            
        }

    void Update()
    {
        
        StartCoroutine(CheckShield());
        //check shield
        


        

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
       

        if (other.gameObject.CompareTag("enemy"))
        {
            hearts.TakeDamage(1);
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