using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPlatform : MonoBehaviour {
    public Transform center;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(center.position, new Vector3(0,0,-1), 0.3f);

	}
}
