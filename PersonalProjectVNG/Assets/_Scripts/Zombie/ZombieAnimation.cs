using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
  private int _movingHash = Animator.StringToHash("Moving");
  private int _attackingHash = Animator.StringToHash("IsAttacking");
  private Animator _animator;
  private ZombieNavigation _navigator;
  private Health _zombieHealth;
  private ZombieAttack _zombieAttack;

  private float _zombieSpeed;
  private void OnValidate()
  {
    _animator = GetComponent<Animator>();
    _navigator = GetComponent<ZombieNavigation>();
    _zombieHealth = GetComponent<Health>();
    _zombieAttack = GetComponent<ZombieAttack>();
  }
  public void InitializeAnimation()
  {
    OnValidate();
    _animator.SetInteger("Anim", UnityEngine.Random.Range(0, 2));
    _animator.SetBool("IsWalking", _zombieSpeed <= 1);
    StartMovement();
  }
  private void Start()
  {
    _zombieSpeed = UnityEngine.Random.Range(0.5f, 1.5f);
    int _zombieDeath = UnityEngine.Random.Range(0, 3);
    _animator.SetInteger("DeathAnim", _zombieDeath);
    InitializeAnimation();
  }
  private void StartMovement()
  {
    _animator.SetBool(_movingHash, true);
    _animator.speed = _zombieSpeed;
  }
  private void Update()
  {
    if (_navigator.TargetReached())
    {
      if (!_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attacking"))
      {
        Invoke(nameof(ZombieAttack.OnAttack1), 0.2f);
      }
      _animator.SetBool(_movingHash, false);
      _animator.SetBool(_attackingHash, true);
    }
  }

  public void OnDamage(int damage)
  {
    CancelInvoke();
    _animator.speed = 1;
    _animator.SetTrigger("IsShot");
    _zombieHealth.TakeDamage(damage);
    if (_zombieHealth.IsDead)
    {
      Die();
    }
  }
  private void Die()
  {
    _animator.SetTrigger("Death");
    _animator.SetBool(_movingHash, false);
    _animator.SetBool(_attackingHash, false);
    Invoke(nameof(DeactivateZombie), 1.2f);
  }
  public void DeactivateZombie()
  {
    gameObject.SetActive(false);
  }

}
