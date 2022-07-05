using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeShooting : Shooting
{
  protected readonly int ShootTrigger = Animator.StringToHash("Shoot");

  private ObjectPool _grenadeBulletPool;

  [SerializeField]
  protected Transform _firingPos;
  private void OnValidate()
  {
    _grenadeBulletPool = GetComponent<ObjectPool>();
  }

  private void Update()
  {
    if (Input.GetButtonDown("Fire1"))
    {
      Fire();
    }
  }
  protected override void Fire()
  {
    _animator.SetTrigger(ShootTrigger);
    base.Fire();
  }
  public void AddProjectile()
  {
    GrenadeBullet bullet = _grenadeBulletPool.SpawnObject(_firingPos.position, _firingPos.transform.rotation).GetComponent<GrenadeBullet>();
    bullet.Launch();
  }
}
