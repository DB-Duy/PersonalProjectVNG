using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
  [SerializeField]
  private int _scoreOnKill = 10;
  private readonly int DieHash = Animator.StringToHash("Death");

  private Animator _animator;
  private GameFlowManager _gameFlow;

  [SerializeField]
  private int _maxHealth;

  public int HealthValue;
  [SerializeField]
  private UnityEvent OnDamageTaken;
  [SerializeField]
  private UnityEvent OnDeath;

  public bool IsDead => HealthValue <= 0;

  private void Start()
  {
    _gameFlow = GameObject.FindGameObjectWithTag("GameFlowManager").GetComponent<GameFlowManager>();
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
      OnDeath?.Invoke();
      AddScore();
      HealthValue = 0;
    }
  }

  private void AddScore()
  {
    if (gameObject.CompareTag("Enemies"))
    {
      _gameFlow.AddScore(_scoreOnKill);
    }
  }
}
