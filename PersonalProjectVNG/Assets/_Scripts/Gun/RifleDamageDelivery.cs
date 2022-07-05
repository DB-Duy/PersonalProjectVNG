using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleDamageDelivery : MonoBehaviour
{
  [SerializeField]
  private Transform _aimingCamera;
  [SerializeField]
  private GameObject _hitEffect;

  [SerializeField]
  private int _damage;
  [SerializeField]
  private float _bloomLimit = 3f;
  [SerializeField]
  private float _hitEffectRange = 50;
  [SerializeField]
  private float _gunRange = 500f;
  [SerializeField]
  private float _headShotMultiplier = 1.5f;

  private float _lastShotTime;
  private float _currentBloom;
  private float _bloomInterval = 0.3f;

  public void OnShoot() => PerformRaycasting();


  private void PerformRaycasting()
  {
    ApplyBloom();
    if (Physics.Raycast(_aimingCamera.position, GetBloomedPosition(), out RaycastHit hitInfo, _gunRange))
    {
      ZombieAnimation anim = hitInfo.collider.gameObject.GetComponentInParent<ZombieAnimation>();
      float damage = (hitInfo.collider.CompareTag("Head")) ? _damage * _headShotMultiplier : _damage;

      if (anim != null)
      {
        anim.OnDamage((int)damage);
      }
      CreateHitEffect(hitInfo);
    }
    _lastShotTime = Time.time;
  }

  private void ApplyBloom()
  {
    if (Time.time - _lastShotTime <= _bloomInterval)
    {
      _currentBloom = Mathf.Lerp(_currentBloom, _bloomLimit, (Time.time - _lastShotTime) / _bloomInterval);
    }
    else
    {
      _currentBloom = 0;
    }
  }

  private Vector3 GetBloomedPosition()
  {
    Vector3 bloom = _aimingCamera.position + _aimingCamera.forward * _gunRange;
    bloom += UnityEngine.Random.Range(-_currentBloom, _currentBloom) * _aimingCamera.up;
    bloom += UnityEngine.Random.Range(-_currentBloom, _currentBloom) * _aimingCamera.right;
    bloom -= _aimingCamera.position;
    bloom.Normalize();

    return bloom;
  }


  private void CreateHitEffect(RaycastHit hitInfo)
  {
    if (Vector3.SqrMagnitude(hitInfo.transform.position - _aimingCamera.position) >= Mathf.Pow(_hitEffectRange, 2))
    {
      return;
    }

    Quaternion holeRotation = Quaternion.LookRotation(hitInfo.normal);
    GameObject hitEffect = Instantiate(_hitEffect, hitInfo.point, holeRotation, hitInfo.collider.transform);
  }
}
