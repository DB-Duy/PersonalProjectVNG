using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour {
	
private Material mat;
 
     void Start () {
         mat = gameObject.GetComponent<MeshRenderer>().material;
     }
     
     void Update () {
		 
             Color newColor = mat.color;
             newColor.a -= Time.deltaTime / 10;
             mat.color = newColor;
			 Destroy (gameObject, 10);

     }
 }