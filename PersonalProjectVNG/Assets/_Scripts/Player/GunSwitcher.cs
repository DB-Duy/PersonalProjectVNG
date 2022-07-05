using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
  private GameObject[] guns;

  private GameObject _currentGun;

  private bool _isEnable = true;
  private void Start()
  {
    guns = GameObject.FindGameObjectsWithTag("Weapons");
    foreach (var gun in guns)
    {
      gun.SetActive(false);
    }
    SwitchToGun(0);
  }

  public void DisableGun()
  {
    _currentGun.SetActive(false);
    _isEnable = false;
  }

  public void EnableGun(int defaultGun)
  {
    SwitchToGun(defaultGun);
    _isEnable = true;
  }

  private void Update()
  {
    if (!_isEnable) return;

    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      SwitchToGun(0);
    }
    if (Input.GetKeyDown(KeyCode.Alpha2))
    {
      SwitchToGun(1);
    }
  }

  private void SwitchToGun(int gunIndex)
  {
    if (_currentGun != null)
    {
      _currentGun.SetActive(false);
    }
    _currentGun = guns[gunIndex];
    _currentGun.SetActive(true);
  }
}
