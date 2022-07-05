using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
	
	public float delay = 3f;
	public float radius = 5f;
	public float force = 500f;
	
	public GameObject explosionEffect;
	
	float countdown;
	bool hasExploded = false;
	
	void Start (){
		countdown = delay;
	}
		
		void Update () {
			countdown -= Time.deltaTime;
			if (countdown <= 0f && !hasExploded)
			{
				Explode();
				hasExploded = true;
			}
		}
		
		void Explode ()
		{
			Instantiate(explosionEffect, transform.position, transform.rotation);
			Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);
			foreach (Collider nearbyObject in collidersToDestroy)
			{
     			DestructibleObject dest = nearbyObject.GetComponent<DestructibleObject>();
				if (dest != null)
				{
					dest.Destroy();
				}
			
			}
			Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);
			foreach (Collider nearbyObject in collidersToMove)
			{
			    Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
				if (rb != null)
				{
					rb.AddExplosionForce(force, transform.position, radius);
				}
				
			}
			
			Destroy(gameObject);
			
		}
	}
	
		 	