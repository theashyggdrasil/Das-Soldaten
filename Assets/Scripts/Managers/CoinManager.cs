using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
            BossEnemyManager.instance.BossEnemyHealthDecrease();
            
        }
    }

    private void Start()
    {
        StartCoroutine("DeathTime");
    }

    IEnumerator DeathTime()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }
}
