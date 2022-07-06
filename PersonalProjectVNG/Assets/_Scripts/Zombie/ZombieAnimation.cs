using System;
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
  private void Awake()
  {
    _animator = GetComponent<Animator>();
    _navigator = GetComponent<ZombieNavigation>();
    _zombieHealth = GetComponent<Health>();
    _zombieAttack = GetComponent<ZombieAttack>();
  }
  public void InitializeAnimation()
  {
    InitializeAttackEvents();
    _animator.SetInteger("Anim", UnityEngine.Random.Range(0, 2));
    _animator.SetBool("IsWalking", _zombieSpeed <= 1);
    StartMovement();
  }

  private void InitializeAttackEvents()
  {
    bool assignedA = false;
    bool assignedB = false;
    for (int i = 0; i < _animator.runtimeAnimatorController.animationClips.Length; i++)
    {
      if (_animator.runtimeAnimatorController.animationClips[i].events.Length != 0)
      {
        continue;
      }
      if (_animator.runtimeAnimatorController.animationClips[i].name == "TZ_aggresive_attack_A")
      {
        assignedA = true;
        AddAttackEvent(_animator.runtimeAnimatorController.animationClips[i], nameof(ExecuteZombieAttack));
      }
      else if (_animator.runtimeAnimatorController.animationClips[i].name == "TZ_aggresive_attack_B")
      {
        assignedB = true;
        AddAttackEvent(_animator.runtimeAnimatorController.animationClips[i], nameof(ExecuteZombieAttack));
      }
      if (assignedA && assignedB)
      {
        return;
      }
    }
  }

  private void Start()
  {
    _zombieSpeed = UnityEngine.Random.Range(1f, 1.5f);
    int _zombieDeath = UnityEngine.Random.Range(0, 3);
    _animator.SetInteger("DeathAnim", _zombieDeath);
    InitializeAnimation();
  }

  private void AddAttackEvent(AnimationClip clip, string functionName)
  {
    AnimationEvent attack = new AnimationEvent();
    attack.functionName = functionName;
    attack.time = (clip.length / 2);
    clip.AddEvent(attack);
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
      _animator.SetBool(_movingHash, false);
      _animator.SetBool(_attackingHash, true);
    }
  }

  public void ExecuteZombieAttack()
  {
    _zombieAttack.OnAttack();
  }

  public void OnDamage(int damage)
  {
    if (_zombieHealth.IsDead)
    {
      return;
    }

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
