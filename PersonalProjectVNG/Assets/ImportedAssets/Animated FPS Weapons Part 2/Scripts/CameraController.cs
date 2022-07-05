using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity;
    public GameObject activeObject;
	public float shakePower;
    public float shakeDuration;
    public Transform mainCamera;
    public float slowdownAmount;
    public bool canShake = false;

Vector3 startPosition;
float initialDuration;
	
    float xAxisClamp = 0.0f;

    void Awake()
    {
		activeObject.SetActive(true);
		Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	    mainCamera = Camera.main.transform;
	    startPosition = mainCamera.localPosition;
	    initialDuration = shakeDuration;
    }

    void Update()
    {
        RotateCameraAndShake();       
    }

    void RotateCameraAndShake()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        xAxisClamp -= rotAmountY;

        Vector3 targetRotCam = transform.rotation.eulerAngles;
        Vector3 targetRotBody = playerBody.rotation.eulerAngles;

        targetRotCam.x -= rotAmountY;
        targetRotCam.z = 0;
        targetRotBody.y += rotAmountX;

        if(xAxisClamp > 90)
        {
            xAxisClamp = 90;
            targetRotCam.x = 90;
        }
        else if(xAxisClamp < -90)
        {
            xAxisClamp = -90;
            targetRotCam.x = 270;
        }


        transform.rotation = Quaternion.Euler(targetRotCam);
        playerBody.rotation = Quaternion.Euler(targetRotBody);
		
		 GameObject[] explosion = GameObject.FindGameObjectsWithTag("Explosion");
	     foreach(GameObject target in explosion) {
         float distance = Vector3.Distance(target.transform.position, transform.position);
         if(distance < 25) {
             canShake = true;  
         }
     }

     if(canShake)
	{
		if(shakeDuration > 0)
		{
			mainCamera.localPosition = startPosition + Random.insideUnitSphere * shakePower;
			shakeDuration -= Time.deltaTime * slowdownAmount;
		}
		else
		{
			canShake = false;
			shakeDuration = initialDuration;
			mainCamera.localPosition = startPosition;
		}
	}
	}	
}
