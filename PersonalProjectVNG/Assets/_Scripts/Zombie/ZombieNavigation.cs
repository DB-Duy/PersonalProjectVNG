using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ZombieNavigation : MonoBehaviour
{
  [SerializeField]
  private Transform _target;

  [SerializeField]
  private float _attackRange = 2;

  [SerializeField]
  [HideInInspector]
  private NavMeshAgent _navAgent;
  [SerializeField]
  [HideInInspector]
  private Animator _animator;


  private bool _isChasing;

  public bool TargetReached()
  {
    return _navAgent.isStopped || (Vector3.SqrMagnitude(transform.position - _target.position) < Mathf.Pow(_attackRange, 2));
  }

  private void OnValidate()
  {
    _navAgent = GetComponent<NavMeshAgent>();
    _animator = GetComponent<Animator>();
  }
  public void InitializeNavigation(Transform target)
  {
    _target = target;
    _navAgent.SetDestination(_target.position);
  }
}
