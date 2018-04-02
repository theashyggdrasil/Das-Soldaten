using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNonPlayerObjectsZone : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Ground")
        {
            Destroy(other.gameObject);
        }
    }
}
