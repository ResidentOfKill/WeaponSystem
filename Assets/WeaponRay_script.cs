using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponRay_script : MonoBehaviour
{


    [SerializeField] private int _maxAmmo = 1;
    [SerializeField] private float _reloadTime = 1;
    [SerializeField] private int _dmg = 1;
    [SerializeField] private float _range = 1f;

    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private GameObject _projectilePrefab;

    private int _currentAmmo;
    private bool _isReloading;

    private Coroutine _reloadingCoroutine;



    private void OnEnable()
    {
        _currentAmmo = _maxAmmo;
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && !_isReloading)
        {
            if (_currentAmmo <= 0 && _reloadingCoroutine == null)
            {
                Debug.Log("ammo EMPTY ");
                _reloadingCoroutine = StartCoroutine(WaitForReaload(_reloadTime));
            }
            if (_currentAmmo > 0)
            {
                Fire();
            }
        }
    }

    public void Fire()
    {
        Debug.Log("FIRE");
        _currentAmmo--;
        Debug.Log("Current Ammo = " + _currentAmmo);

        RaycastHit hit;
        if (Physics.Raycast(_spawnpoint.position, _spawnpoint.forward,out hit,_range)) {
            Debug.Log(hit.collider.name);
            if (hit.collider.TryGetComponent(out Enemy_script enemy))
            {
                enemy.TakeDamage(_dmg);
            }
        }
    }

    public IEnumerator WaitForReaload(float t)
    {
        _isReloading = true;
        yield return new WaitForSeconds(t);
        _isReloading = false;
        _currentAmmo = _maxAmmo;
        _reloadingCoroutine = null;
    }
}
