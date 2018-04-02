using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFallingRisingTile : MonoBehaviour {

    public Vector2 fallVelocity, riseVelocity;
    public Rigidbody2D rb;
    private bool shouldRise, shouldFall;
    public float timerTime;


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            int randomInt = Random.Range(0, 1);

            if (randomInt == 1)
                shouldRise = true;
            else if (randomInt == 0)
                shouldFall = true;

            
        }

    }

    private void Awake()
    {


    }
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (shouldRise == true)
        {
            StartCoroutine("RiseTimer");
        }
        if (shouldFall == true)
        {
            StartCoroutine("FallTimer");
        }
    }


    void Fall()
    {
        rb.MovePosition(rb.position + fallVelocity * Time.fixedDeltaTime);
    }

    void Rise()
    {
        rb.MovePosition(rb.position + riseVelocity * Time.fixedDeltaTime);
    }

    IEnumerator RiseTimer()
    {
        yield return new WaitForSeconds(timerTime);
        Rise();
    }

    IEnumerator FallTimer()
    {
        yield return new WaitForSeconds(timerTime);
        Fall();
    }
}
