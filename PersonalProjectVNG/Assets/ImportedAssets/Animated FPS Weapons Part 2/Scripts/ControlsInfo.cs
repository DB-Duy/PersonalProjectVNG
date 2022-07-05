using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsInfo : MonoBehaviour {

public GameObject Text01;
public GameObject Text02;
private bool ShowHide;


	// Use this for initialization
void Start () {

}
	
// Update is called once per frame
void Update () {

if(Input.GetKeyDown(KeyCode.Tab)){ 
	if(ShowHide){
	ShowHide = false;	
	Text01.SetActive (true);
	if(Text02 == null){
		Text02 = null;
		}
	else{
	Text02.SetActive (true);
	}
	}
	else{
	ShowHide = true;	
	Text01.SetActive (false);
	Destroy (Text02);
	}
	}
}
}