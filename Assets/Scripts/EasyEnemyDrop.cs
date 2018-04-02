using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemyDrop : MonoBehaviour {

    public GameObject enemyEasy, dropSpot;
    

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Drop();
            Destroy(this);

        }
    }

    public void Drop()
    {
        GameObject clone;
        clone = Instantiate(enemyEasy, dropSpot.transform.position, transform.rotation) as GameObject;
        
    }
}
