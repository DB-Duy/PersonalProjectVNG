using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByMouse : MonoBehaviour
{
  private Transform _playerTransform;
  [SerializeField]
  private Transform cameraHolder;
  [SerializeField]
  private float sensitivity;
  [SerializeField]
  private float minPitch;
  [SerializeField]
  private float maxPitch;

  private bool allowRotate = false;
  private void OnValidate()
  {
    _playerTransform = GetComponent<Transform>();
  }
  private void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = true;
    Invoke(nameof(EnableRotation), 0.5f);
  }
  private void Update()
  {
    if (!allowRotate) return;

    UpdateYaw();

    UpdatePitch();
  }

  private void EnableRotation()
  {
    allowRotate = true;
  }

  private void UpdateYaw()
  {
    float mouseDX = Input.GetAxisRaw("Mouse X");
    transform.Rotate(0, mouseDX * sensitivity, 0);
    ClampRotationAngle();
  }

  private void ClampRotationAngle()
  {
    float yaw = _playerTransform.localEulerAngles.y;
    yaw = Mathf.Clamp(yaw, 135, 225);
    _playerTransform.localEulerAngles = new Vector3(cameraHolder.localEulerAngles.x, yaw, 0);
  }

  private void UpdatePitch()
  {
    float mouseDY = Input.GetAxisRaw("Mouse Y");
    cameraHolder.Rotate(-mouseDY * sensitivity, 0, 0);
    ClampPitchAngle();
  }

  private void ClampPitchAngle()
  {
    float pitch = cameraHolder.localEulerAngles.x;
    while (pitch > 180)
    {
      pitch -= 360;
    }
    while (pitch < -180)
    {
      pitch += 360;
    }
    pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
    cameraHolder.localEulerAngles = new Vector3(pitch, 0, 0);
  }
}
