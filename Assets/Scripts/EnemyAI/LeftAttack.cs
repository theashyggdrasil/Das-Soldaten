using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAttack : MonoBehaviour {
    public Rigidbody2D rb; // initializes an rigidbody for our sprite
    public Vector2 thrustLeft;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            rb = GetComponentInParent<Rigidbody2D>();
            rb.AddForce(thrustLeft, ForceMode2D.Impulse);

        }
    }
}
