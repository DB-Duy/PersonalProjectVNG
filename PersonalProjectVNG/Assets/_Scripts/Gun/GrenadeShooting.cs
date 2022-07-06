using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeShooting : Shooting
{
  protected readonly int ShootTrigger = Animator.StringToHash("Shoot");

  private ObjectPool _grenadeBulletPool;

  [SerializeField]
  private float _fireCooldown = 0.2f;

  private float _lastShotTime;

  [SerializeField]
  protected Transform _firingPos;
  private void Start()
  {
    _animator = GetComponent<Animator>();
    _buttonManager = GameObject.FindGameObjectWithTag("ButtonManager").GetComponent<ButtonManager>();
    _grenadeBulletPool = GetComponent<ObjectPool>();
  }

  private void Update()
  {
    if (_buttonManager.FireButtonPressed)
    {
      Fire();
    }
  }
  protected override void Fire()
  {
    if (Time.time - _lastShotTime >= _fireCooldown)
    {
      _animator.SetTrigger(ShootTrigger);
      base.Fire();
      _lastShotTime = Time.time;
    }
  }
  public void AddProjectile()
  {
    GrenadeBullet bullet = _grenadeBulletPool.SpawnObject(_firingPos.position, _firingPos.transform.rotation).GetComponent<GrenadeBullet>();
    bullet.Launch();
  }
}
