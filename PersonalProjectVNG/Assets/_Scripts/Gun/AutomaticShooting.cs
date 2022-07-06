using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticShooting : Shooting
{
    protected readonly int FireStateHash = Animator.StringToHash("AlternateSingleFire");
    
    [SerializeField]
    private float _rpm;
    private bool _isFiring = false;
    private float _lastShotTime;

    private void Update()
    {
        _isFiring = _buttonManager.IsFiring;

        if (_isFiring)
        {
            UpdateFiring();
        }
    }

    private void StartFiring()
    {
        _isFiring = true;
    }

    private void StopFiring()
    {
        _isFiring = false;
    }

    protected override void Fire()
    {
        base.Fire();
        _animator.Play(FireStateHash, layer: 0, normalizedTime: 0);
    }


    private void UpdateFiring()
    {
        float interval = 60 / _rpm;
        if (Time.time - _lastShotTime >= interval)
        {
            Fire();
            _lastShotTime = Time.time;
        }
    }
}
