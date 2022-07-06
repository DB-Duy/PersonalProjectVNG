using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
  [HideInInspector]
  public bool IsFiring;

  public bool FireButtonPressed;
  public bool FireButtonReleased;

  private void LateUpdate()
  {
    if (FireButtonPressed)
    {
      FireButtonPressed = false;
    }
    if (FireButtonReleased)
    {
      FireButtonReleased = false;
    }
  }



  public void StartFiring()
  {
    IsFiring = true;
  }
  public void StopFiring()
  {
    IsFiring = false;
  }
  public void FireButtonDown()
  {
    FireButtonPressed = true;
  }
  public void FireButtonUp()
  {
    FireButtonReleased = true;
  }
}
