using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private Transform _target;

    private Vector3 _targetDelta;

    private void Awake() {
        _targetDelta = transform.position - _target.position;
    }

    private void FixedUpdate() {
        transform.position = _targetDelta + _target.position;
    }
}
