using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyMove : MonoBehaviour {
    public int Speed;
    public int XaxisMovement;

	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XaxisMovement, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XaxisMovement, 0) * Speed;
        if (hit.distance < 1.0f)
        {
            Debug.Log("Enemy has hit a wall");
            flipsprite();
            if (hit.collider.tag == "Player")
            {
                Destroy(hit.collider.gameObject);
            }

        }
	}
    void flipsprite()
    {
        XaxisMovement *= -1;
    }
}
