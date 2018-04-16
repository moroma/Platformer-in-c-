using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
    public int movementspeed = 10;
    public int jumpheight = 1250;
    public bool playerright = true;
    public float movementX;
    public bool onground = false;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        playercast();
    }

    void PlayerMovement() {
        movementX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && onground == true)
        {
            jump();
        }
        //movement animations (to do)
        //movement directions
        if (movementX < 0.0f && playerright == false)
        {
            playerflip();
        } else if (movementX > 0.0f && playerright == true)
        {
            playerflip();
        }

        // game physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(movementX * movementspeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}
    void jump()
    {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * jumpheight);
        onground = false;
    }

    void playerflip()
    {
        playerright = !playerright;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            onground = true;
        }
    }

    void playercast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit != null&& hit.collider !=null && hit.distance < 1.2f && hit.collider.tag == "enemies")
        {
            // Destroy(hit.collider.gameObject);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 100);
            hit.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 500);
            hit.collider.gameObject.GetComponent<EmenyMove>().enabled = false;
            hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;

        }
        if (hit != null && hit.collider != null && hit.distance < 1.2f && hit.collider.tag != "enemies")
        {
            onground = true;
        }
     
    }
}
