using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBullet : MonoBehaviour
{
  [SerializeField]
  [HideInInspector]
  private Rigidbody _rigidbody;
  [SerializeField]
  private float _launchingForce;
  [SerializeField]
  private float _explosionTime;
  [SerializeField]
  private float _explosionRadius;
  [SerializeField]
  private float _explosionForce;
  [SerializeField]
  private int _damage;
  [SerializeField]
  private LayerMask _hitLayer;

  [SerializeField]
  private GameObject _explosionEffect;

  private List<Health> _processedVictims = new List<Health>();



  private void OnValidate()
  {
    _rigidbody = GetComponent<Rigidbody>();
  }


  public void Launch()
  {
    _rigidbody.velocity = transform.forward * _launchingForce;
    Invoke(nameof(Explode), _explosionTime);
  }

  private void OnCollisionEnter(Collision other)
  {
    Explode();
  }

  void Explode()
  {
    CancelInvoke();
    if (!gameObject.activeInHierarchy)
    {
      return;
    }

    // _processedVictims.Clear();

    Instantiate(_explosionEffect, transform.position, Quaternion.identity);

    Collider[] victims = Physics.OverlapSphere(transform.position, _explosionRadius, _hitLayer);
    for (int i = 0; i < victims.Length; i++)
    {
      DeliveryDamage(victims[i]);
    }
    gameObject.SetActive(false);
  }

  private void DeliveryDamage(Collider victim)
  {
    ZombieAnimation animator = victim.gameObject.GetComponent<ZombieAnimation>();

    animator?.OnDamage(_damage);

    // if (health != null && !_processedVictims.Contains(health))
    // {
    //   health.TakeDamage(_damage);
    //   _processedVictims.Add(health);
    // }
  }
}
