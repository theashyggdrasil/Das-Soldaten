using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneOpenShotManager : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
