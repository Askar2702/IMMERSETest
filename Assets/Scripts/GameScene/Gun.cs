using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private RayGun _rayGun;
    [SerializeField] private Transform _startPosRay;
    [SerializeField] private LayerMask _layerMask;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_rayGun.ShootBeam(_startPosRay.position, transform.TransformDirection(Vector3.forward), _layerMask)) return;
            var target = _rayGun.ShootBeam(_startPosRay.position, transform.TransformDirection(Vector3.forward), _layerMask).GetComponent<ITarget>();
           
            if (target is ITarget)
            {
                target.TakeDamage();
            }
        }
    }
}
