using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    [SerializeField] private float _damamgeCooldown;
    private bool _isDamageable = true;

    private MeshRenderer _renderer;


    private void OnEnable()
    {
        _renderer = GetComponent<MeshRenderer>();
    }

    public void TakeDamage(int damage)
    {
        if(_isDamageable)
        {
            StartCoroutine(DamageCooldown());
        }
    }

    public IEnumerator DamageCooldown() 
    {
        _isDamageable = false;
        _renderer.material.color = Color.red;
        yield return new WaitForSeconds(_damamgeCooldown);
        _renderer.material.color = Color.white;
        _isDamageable = true;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
