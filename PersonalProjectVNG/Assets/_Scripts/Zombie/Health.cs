using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
  private readonly int DieHash = Animator.StringToHash("Death");

  private Animator _animator;
  [SerializeField]
  private int _maxHealth;

  public int HealthValue;
  [SerializeField]
  private UnityEvent OnDamageTaken;

  public bool IsDead => HealthValue <= 0;

  private void Start()
  {
    InitializeHealth();
  }
  private void OnValidate()
  {
    _animator = GetComponent<Animator>();
  }
  public void InitializeHealth()
  {
    HealthValue = _maxHealth;
  }

  public void TakeDamage(int damage)
  {
    if (IsDead) return;

    HealthValue -= damage;
    OnDamageTaken?.Invoke();
    if (HealthValue <= 0)
    {
      HealthValue = 0;
    }
  }

}
