using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killspot : MonoBehaviour {
    private int enemyHealth = 2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerManager.instance.BounceOff();
            enemyHealth--;
            if (enemyHealth == 0)
            {
                Destroy(transform.parent.gameObject);
                for (int i = 0; i < 5; i++)
                {
                    GameManager.instance.AddScore();
                }

            }
        }

    }
}
