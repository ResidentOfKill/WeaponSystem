using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_script : MonoBehaviour
{


    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _liveSpan = 1f;
    [SerializeField] private int _dmg = 1;
    [SerializeField] private Rigidbody _rb;
    
    private Vector3 _direction;
    // Start is called before the first frame update

    private void OnEnable()
    {
        _rb= GetComponent<Rigidbody>();
        _direction = transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("ENEMY SPOTTED");
        }
    }




    void Fire()
    {
        _rb.AddForce(_direction*_speed,ForceMode.Impulse);
    }
        
    private IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(_liveSpan);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
