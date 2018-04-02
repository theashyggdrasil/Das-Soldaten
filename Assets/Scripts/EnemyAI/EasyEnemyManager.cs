using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemyManager : MonoBehaviour {

    private Rigidbody2D rigidBody; // initializes an rigidbody for our sprite


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerManager.instance.BounceOff();
            Destroy(gameObject);
            GameManager.instance.AddScore();
        }
    }
    // Use this for initialization
    void Awake () {
        rigidBody = GetComponent<Rigidbody2D>(); // sets up the rigidbody component
        rigidBody.freezeRotation = true; // does not allow for rotation of the rigidbody to disable falling over
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
