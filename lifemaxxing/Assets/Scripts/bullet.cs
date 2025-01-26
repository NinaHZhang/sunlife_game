using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 5f;
    public bool isFacingLeft;
    public bool isFacingDown;
    public bool isFacingUp;
    private enemy enemy;
    // Update is called once per frame

    private void Start()
    {
        deleteAfterSpawning();
    }
    void Update()
    {

        if (isFacingLeft == true && isFacingDown == false)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (isFacingLeft == false && isFacingDown == false && isFacingUp == false)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (isFacingLeft == false && isFacingDown == true)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (isFacingLeft == false && isFacingDown == false && isFacingUp == true)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy") {

            enemy = collision.gameObject.GetComponent<enemy>();
            enemy.gotHit();
            Destroy(this.gameObject);

        }
    }

    private IEnumerator deleteAfterSpawning()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
}
