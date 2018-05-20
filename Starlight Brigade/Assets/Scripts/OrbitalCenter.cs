using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCenter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.position += new Vector3(0, -0.02f, 0) * Time.deltaTime * 10;
    }
}
