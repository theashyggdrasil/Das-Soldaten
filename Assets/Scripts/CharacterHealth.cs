using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour {
    public LayerMask enemyLayer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "MediumEnemy")
        {

            
            PlayerManager.instance.CharacterHealth(true);
            Collider2D collider = collision.collider;

            Vector2 center = collider.bounds.center;
            Vector2 contactPoint = collision.contacts[0].point;

            if (contactPoint.x < center.x)
            {
                PlayerManager.instance.Recoil(true);

            }
            else if (contactPoint.x > center.x)
            {
                PlayerManager.instance.Recoil(false);

            }
        }

        else if (collision.gameObject.tag == "OneOpenShotAttack")
        {
            PlayerManager.instance.CharacterHealth(true);
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }
    
}
