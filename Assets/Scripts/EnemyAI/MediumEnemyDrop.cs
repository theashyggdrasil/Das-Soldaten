using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyDrop : MonoBehaviour {

    public Transform enemyMedium, dropSpot;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Drop();
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }


    public void Drop()
    {

        Instantiate(enemyMedium, dropSpot.position, transform.rotation);

    }
}
