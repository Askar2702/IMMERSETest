
using UnityEngine;

public class RayGun : MonoBehaviour
{
    //transform.TransformDirection(Vector3.forward)
    public GameObject ShootBeam(Vector3 startPos , Vector3 direction , LayerMask layerMask)
    {
        RaycastHit hit;
        GameObject target = null;
        if (Physics.Raycast(startPos, direction, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(startPos, direction * hit.distance, Color.yellow);

            target = hit.collider.gameObject;
        }
        return target;
    }
}
