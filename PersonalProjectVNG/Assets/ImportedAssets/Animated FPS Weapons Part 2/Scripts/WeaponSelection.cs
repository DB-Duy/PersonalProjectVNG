using UnityEngine;

public class WeaponSelection : MonoBehaviour {
	
public int selectedWeapon = -1;
private bool showUnarmed = true;
private bool keyIsPressed = false;

void start () {
	 
SelectWeapon ();

 }
 
void Update () {
	
if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.LeftShift))
{
	keyIsPressed = true;
}
else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.LeftShift))
{
keyIsPressed = false;	
}

int previousSelectedWeapon = selectedWeapon;

if (Input.GetAxis("Mouse ScrollWheel") < 0f && keyIsPressed == false)
	 {
		 showUnarmed = false;
		 if (selectedWeapon >= transform.childCount - 1)
			 selectedWeapon = 0;
		 else
		 selectedWeapon++;
	 }
if (Input.GetAxis("Mouse ScrollWheel") > 0f && keyIsPressed == false)
	 {
		 showUnarmed = false;
		 if (selectedWeapon <= 0)
			 selectedWeapon = transform.childCount - 1;
		 else
		 selectedWeapon--;
	 }
	 	 if (Input.GetKeyDown(KeyCode.Alpha0) || showUnarmed == true || Input.GetKeyDown(KeyCode.Keypad0))
	 {
		 selectedWeapon = 0;
		 
	 }
	 if (Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >= 1 && keyIsPressed == false || Input.GetKeyDown(KeyCode.Keypad1) && transform.childCount >= 1 && keyIsPressed == false)
	 {
		 selectedWeapon = 1;
		 showUnarmed = false;
		 
	 }
	 
	 	 if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2 && keyIsPressed == false || Input.GetKeyDown(KeyCode.Keypad2) && transform.childCount >= 2 && keyIsPressed == false)
	 {
		 selectedWeapon = 2;
		 showUnarmed = false;
	 }
	 
	 	 	 if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3 && keyIsPressed == false || Input.GetKeyDown(KeyCode.Keypad3) && transform.childCount >= 3 && keyIsPressed == false)
	 {
		 selectedWeapon = 3;
		 showUnarmed = false;
	 }
	 
	 	 	 if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4 && keyIsPressed == false || Input.GetKeyDown(KeyCode.Keypad4) && transform.childCount >= 4 && keyIsPressed == false)
	 {
		 selectedWeapon = 4;
		 showUnarmed = false;
	 }
	 
	 	 	 if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 5 && keyIsPressed == false || Input.GetKeyDown(KeyCode.Keypad5) && transform.childCount >= 5 && keyIsPressed == false)
	 {
		 selectedWeapon = 5;
		 showUnarmed = false;
	 }
	 
	 	 	 if (Input.GetKeyDown(KeyCode.Alpha6) && transform.childCount >= 6 && keyIsPressed == false || Input.GetKeyDown(KeyCode.Keypad6) && transform.childCount >= 6 && keyIsPressed == false)
	 {
		 selectedWeapon = 6;
		 showUnarmed = false;
	 }
	 
	 	 	 if (Input.GetKeyDown(KeyCode.Alpha7) && transform.childCount >= 7 && keyIsPressed == false || Input.GetKeyDown(KeyCode.Keypad7) && transform.childCount >= 7 && keyIsPressed == false)
	 {
		 selectedWeapon = 7;
		 showUnarmed = false;
	 }
	 if (previousSelectedWeapon != selectedWeapon)
	 {
		 SelectWeapon ();
	 }
}

void SelectWeapon ()
 {
	 int i = 0;
	 foreach (Transform weapon in transform)
	 {
		 if (i == selectedWeapon)
			 weapon.gameObject.SetActive(true);
		 else
			 weapon.GetComponent<Gun_Controller>().Deactivation();
                i++;
	 }
	  }
}

		 