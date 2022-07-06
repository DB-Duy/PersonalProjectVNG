using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
  [SerializeField]
  private int _damage;
  [SerializeField]
  private Health _playerHealth;

  private void Start()
  {
    _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
  }

  public void OnAttack()
  {
     _playerHealth.TakeDamage(_damage);
  }

}
