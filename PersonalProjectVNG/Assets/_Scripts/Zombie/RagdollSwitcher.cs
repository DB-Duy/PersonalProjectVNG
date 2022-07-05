using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RagdollSwitcher : MonoBehaviour
{
    [SerializeField]
    private Rigidbody[] _rigidbodies;
    [SerializeField]
    private NavMeshAgent _navAgent;
    [SerializeField]
    private Animator _animator;

    private void OnValidate()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _navAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        //DisableRagdoll();
    }

    [ContextMenu("Enable Ragdoll")]
    public void EnableRagdoll() => SetRagdoll(true);

    [ContextMenu("Disable Ragdoll")]
    public void DisableRagdoll() => SetRagdoll(false);

    private void SetRagdoll(bool enableValue)
    {
        _animator.enabled = !enableValue;
        _navAgent.enabled = !enableValue;
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = !enableValue;
        }
    }
}
