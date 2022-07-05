using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
  [SerializeField]
  private int _damage;
  [SerializeField]
  private Health _playerHealth;


  public void OnAttack1()
  {
    _playerHealth.TakeDamage(_damage);
  }
  public void OnAttack2()
  {
    _playerHealth.TakeDamage(_damage);
  }

}
