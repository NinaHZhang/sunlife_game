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
            }
            if (Input.GetAxisRaw("Horizontal") >= 1f)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                isFacingLeft = false;
            }

        }

        if (isFacingLeft)
        {
            if (Input.GetKeyDown("space"))
            {
                ShootBulletLeft();
            }
        }

        if (!isFacingLeft)
        {
            if (Input.GetKeyDown("space"))
            {
                ShootBulletRight();
            }
        }

    }

    private void ShootBulletLeft()
    {
        GameObject newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
        newBullet.GetComponent<bullet>().isFacingLeft = true;

    }

    private void ShootBulletRight()
    {
        GameObject newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation);
        newBullet.GetComponent<bullet>().isFacingLeft = false;

    }

}