using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
	
	public int lifetime = 2 ;

	// Use this for initialization

void Update () {
	
		transform.Rotate(Random.Range(0, 42),Random.Range(0, 46),Random.Range (0, 22));	
        Destroy(gameObject,lifetime);
	
}
}