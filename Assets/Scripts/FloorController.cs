using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {

    private int _layerMask;

    [SerializeField]
    private Transform _playerRoot;

    [SerializeField]
    private MovementController _playerMC;

    private void Awake() {
        _layerMask = LayerMask.GetMask("Floor");
    }

    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(1)) {
            // Warning here: Collider of flat surface should be flat, with Y size equal to zero to be sure no round-up problems occur
            // when calculating hitInfo.point
            RaycastHit hitInfo;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, _layerMask);
            //_playerRoot.transform.InverseTransformPoint(hitInfo.point);
            //_playerRoot.transform.position = hitInfo.point;
            _playerMC.WalkToPosition(hitInfo.point);
        }
        if (Input.GetMouseButtonDown(0)) {
            int c = 0;
        }
    }
}
