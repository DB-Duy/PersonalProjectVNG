using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Shooting : MonoBehaviour
{
  [SerializeField]
  protected Camera _weaponCamera;
  [SerializeField]
  protected AudioSource _fireSfx;
  [SerializeField]
  [HideInInspector]
  protected Animator _animator;

  protected ButtonManager _buttonManager;

  public UnityEvent OnShoot;

  private void Start()
  {
    _buttonManager = GameObject.FindGameObjectWithTag("ButtonManager").GetComponent<ButtonManager>();
  }
  private void OnValidate()
  {
    _animator = GetComponent<Animator>();
  }

  protected virtual void Fire()
  {
    OnShoot?.Invoke();
  }

  public void PlayFireSound() => _fireSfx.Play();

  public void Lock() => enabled = false;
  public void Unlock() => enabled = true;
}
