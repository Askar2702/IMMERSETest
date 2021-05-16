using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Vector3 _rightPos;
    [SerializeField] private Vector3 _leftPos;
    [SerializeField] private float _speed;
    private Vector3 _targetPos;

    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        if (Vector3.Distance(transform.position, _rightPos) < 0.2f) _targetPos = _leftPos;
        else if (Vector3.Distance(transform.position, _leftPos) < 0.2f) _targetPos = _rightPos;
        transform.position = Vector3.Lerp(transform.position, _targetPos, Time.deltaTime * _speed);
    }
}
