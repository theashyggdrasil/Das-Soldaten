using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour {
    public Vector2 velocity;
    public Rigidbody2D rb;
    private bool shouldMove;
    public float timerTime;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
            shouldMove = true;
        }
        
    }

    private void Awake()
    {
        
        
    }
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (shouldMove == true)
        {
            StartCoroutine("Timer");
        }
	}


    void RiseOrFall()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timerTime);
        RiseOrFall();
    }
}
