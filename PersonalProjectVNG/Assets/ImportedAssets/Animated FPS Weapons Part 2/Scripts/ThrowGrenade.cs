using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour {
	
	public GameObject grenade;
	public Transform startPoint;
	public float throwForce = 15f;
	
	
	void Update () {
			GameObject gren = Instantiate (grenade, startPoint.position, startPoint.rotation) as GameObject;
			gren.GetComponent <Rigidbody> ().AddForce(startPoint.forward * throwForce, ForceMode.Impulse);
		
	}
}