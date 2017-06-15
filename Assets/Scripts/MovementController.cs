using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class MovementController : MonoBehaviour {

    [SerializeField]
    private float _walkSpeed, _runSpeed;

    private Animator _animator;
    private Rigidbody _rigidbody;

    private Vector3 _newPosition;

    private bool _isMoving = false;

    private void Awake() {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void WalkToPosition(Vector3 position) {
        var newForward = position - transform.position;
        _newPosition = position;
        transform.forward = newForward;
        _animator.SetTrigger("StartWalking");
        _isMoving = true;
        _rigidbody.velocity = transform.forward * _walkSpeed;
    }

    private void FixedUpdate() {
        if (_isMoving) {
            // transform.position не меняется, несмотря на _rigidbody.velocity > 0. Почему?
            if ((_rigidbody.position - _newPosition).sqrMagnitude < 0.001f) {
                _isMoving = false;
                _rigidbody.velocity = Vector3.zero;
                _animator.SetTrigger("Stop");
            }
        }
    }
}
