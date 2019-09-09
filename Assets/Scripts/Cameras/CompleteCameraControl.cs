using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteCameraControl : MonoBehaviour {
    public GameObject player;

    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
        Screen.fullScreen = true;
        Screen.SetResolution(800, 600, false);

        
    }
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
        
	}
}
