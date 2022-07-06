using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByTouch : MonoBehaviour
{
  [SerializeField]
  private Transform _playerTransform;
  [SerializeField]
  private Transform _cameraHolder;
  [SerializeField]
  private Joystick _lookJoystick;

  [SerializeField]
  private float sensitivity;
  [SerializeField]
  private float minPitch;
  [SerializeField]
  private float maxPitch;

  private void Update()
  {
    UpdateYaw();
    UpdatePitch();
  }
  private void UpdateYaw()
  {
    float joystickDX = _lookJoystick.Horizontal;
    _playerTransform.Rotate(0, joystickDX * sensitivity, 0);
    ClampRotationAngle();
  }

  private void ClampRotationAngle()
  {
    float yaw = _playerTransform.localEulerAngles.y;
    yaw = Mathf.Clamp(yaw, 135, 225);
    _playerTransform.localEulerAngles = new Vector3(_cameraHolder.localEulerAngles.x, yaw, 0);
  }

  private void UpdatePitch()
  {
    float joystickDy = _lookJoystick.Vertical;
    _cameraHolder.Rotate(-joystickDy * sensitivity, 0, 0);
    ClampPitchAngle();
  }

  private void ClampPitchAngle()
  {
    float pitch = _cameraHolder.localEulerAngles.x;
    while (pitch > 180)
    {
      pitch -= 360;
    }
    while (pitch < -180)
    {
      pitch += 360;
    }
    pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
    _cameraHolder.localEulerAngles = new Vector3(pitch, 0, 0);
  }
}
