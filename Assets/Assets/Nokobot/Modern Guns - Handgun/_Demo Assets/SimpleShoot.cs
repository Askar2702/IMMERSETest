using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _casingPrefab;
    [SerializeField] private GameObject _muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator _gunAnimator;
    [SerializeField] private Transform _barrelLocation;
    [SerializeField] private Transform _casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")]
    [SerializeField] private float destroyTimer = 1f;
    [Tooltip("Bullet Speed")] 
    [SerializeField]  private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] 
    [SerializeField] private float ejectPower = 150f;

    [SerializeField] private AudioSource _audioSource;


    private void Start()
    {
        if (_barrelLocation == null)
            _barrelLocation = transform;

        if (_gunAnimator == null)
            _gunAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //If you want a different input, change it here
        if (Input.GetButtonDown("Fire1"))
        {
            //Calls animation on the gun that has the relevant animation events that will fire
            _gunAnimator.SetTrigger("Fire");
        }
    }


    //This function creates the bullet behavior
    private void Shoot()
    {
        if (_muzzleFlashPrefab)
        {
            //Create the muzzle flash
            _audioSource.Play();
            GameObject tempFlash;
            tempFlash = Instantiate(_muzzleFlashPrefab, _barrelLocation.position, _barrelLocation.rotation);

            //Destroy the muzzle flash effect
            Destroy(tempFlash, destroyTimer);
        }

        //cancels if there's no bullet prefeb
        if (!_bulletPrefab)
        { return; }

        // Create a bullet and add force on it in direction of the barrel
        var bullet = Instantiate(_bulletPrefab, _barrelLocation.position, _barrelLocation.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(_barrelLocation.forward * shotPower);
        Destroy(bullet, destroyTimer);
    }

    //This function creates a casing at the ejection slot
    private void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!_casingExitLocation || !_casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(_casingPrefab, _casingExitLocation.position, _casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (_casingExitLocation.position - _casingExitLocation.right * 0.3f - _casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }

}
