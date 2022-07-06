using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectsManager : MonoBehaviour
{
  [SerializeField]
  private Image _bloodOverlay;

  [SerializeField]
  private float _bloodOverlayDuration;
  [SerializeField]
  private Health _playerHealth;


  private float _startTime;


  private void Update()
  {
    if (_playerHealth.IsDead)
    {
      _bloodOverlay.CrossFadeAlpha(255, _bloodOverlayDuration, false);
      return;
    }
    
    if (Time.time - _startTime >= _bloodOverlayDuration)
    {
      StopBloodOverlay();
    }
  }

  private void StopBloodOverlay()
  {
    _bloodOverlay.CrossFadeAlpha(0, _bloodOverlayDuration, false);
  }

  public void StartBloodOverlay()
  {
    _bloodOverlay.CrossFadeAlpha(150, _bloodOverlayDuration, false);
    _startTime = Time.time;
  }
}
