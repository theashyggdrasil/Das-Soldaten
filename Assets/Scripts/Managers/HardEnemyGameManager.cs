using System.Collections;
using UnityEngine;

public class HardEnemyGameManager : MonoBehaviour {

    public GameObject bullet, player;
    public Transform bulletSpawnLocation;
    private Rigidbody2D rb;
    public float bulletSpeed;

    private void Awake()
    {
     
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
                StartCoroutine("ShootCoolDown");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StopCoroutine("ShootCoolDown");
        }
    }


    IEnumerator ShootCoolDown()
    {
       
        for (int i = 0; i < 10; i++)
        {
           Shoot(player.transform.position);
           yield return new WaitForSeconds(0.5f);

        }
        

    }
    void Shoot(Vector3 currentPosition)
    {
        GameObject clone;
        clone = Instantiate(bullet, bulletSpawnLocation.position, transform.rotation) as GameObject;
        rb = clone.GetComponent<Rigidbody2D>();
        float randomX = Random.Range(currentPosition.x - bulletSpawnLocation.transform.position.x - 1.0f, currentPosition.x - bulletSpawnLocation.transform.position.x  + 1.0f);
        float randomY= Random.Range(currentPosition.y - bulletSpawnLocation.transform.position.y - 1.0f, currentPosition.y - bulletSpawnLocation.transform.position.y + 1.0f);
        rb.velocity = new Vector3(randomX, randomY)*bulletSpeed;
    }
}
