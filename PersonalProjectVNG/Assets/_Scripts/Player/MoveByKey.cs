using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveByKey : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    [HideInInspector]
    private CharacterController _controller;

    private void OnValidate()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = transform.forward * verticalInput + transform.right * horizontalInput;
        _controller.SimpleMove(direction * _speed);
    }

    public void UnlockMovement()
    {
        enabled = true;
        _controller.enabled = true;
    }

    public void DetachParent()
    {
        transform.SetParent(null);
    }
}
