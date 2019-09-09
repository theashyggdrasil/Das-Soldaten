using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

    Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerManager.instance.CharacterHealth(false);
            Destroy(gameObject);
        }
        else if(collision.tag == "Ground" && tag != "fireBullet")
            Destroy(gameObject);
        else if (collision.tag == "Ground" && tag == "fireBullet")
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, 0);
            StartCoroutine("DestroyFireBullet");
        }
    }

    private void Awake()
    {
        
    }
    private void Update()
    {
        if(tag == "bubbleBullet")
        transform.Rotate(new Vector3(0, 0, 1.5f));
        else if (tag == "bullet")
            transform.Rotate(new Vector3(0, 0, 5));
        else if (tag == "fireBullet")
        {
            transform.Rotate(new Vector3(0, 0, 5));
        }

        if(gameObject == null)
        {
            StopCoroutine("DestroyFireBullet");
        }
    }
    IEnumerator DestroyFireBullet()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
