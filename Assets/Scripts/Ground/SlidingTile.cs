using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingTile : MonoBehaviour {
    public Rigidbody2D rb;
    public Transform leftEndPosition, rightEndPosition;
    public bool moveLeft;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            Movement();
        }
	}

    void Movement()
    {

        if (moveLeft == true)
        {
            MovementLeft();
        }
        else
            MovementRight();
    }

    void MovementLeft()
    {
        if (rb.position.x >= leftEndPosition.position.x)
        {
            rb.MovePosition(rb.position - new Vector2(0.05f, 0.0f));

        }

    }

    void MovementRight()
    {
        if (rb.position.x < rightEndPosition.position.x)
        {
            rb.MovePosition(rb.position + new Vector2(0.05f, 0.0f));
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EndPoint")
        {
            if (moveLeft == true)
                moveLeft = false;
            else if (moveLeft == false)
                moveLeft = true;
        }
    }
}
