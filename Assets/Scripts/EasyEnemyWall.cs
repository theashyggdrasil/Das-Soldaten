using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemyWall : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MediumEnemy")
        {
            Destroy(gameObject);

            for(int i = 0; i > 5; i++)
            GameManager.instance.AddScore();

        }

    }
}
