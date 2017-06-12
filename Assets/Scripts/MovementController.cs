using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    [SerializeField]
    private Animator _animator;

    private void Awake() {
        _animator = GetComponent<Animator>();
    }

    
}
