using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour

{
    [SerializeField] private float _speed = 5;
    [Tooltip("Time in secs until bullet disappears")]
    [SerializeField] private float _lifespan = 3;
    [SerializeField] private float _damage = 10;

    void Update()
    {
        _lifespan -= Time.deltaTime;

        if (_lifespan > 0)
        {
            transform.position += transform.right * Time.deltaTime * _speed;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject target = collision.gameObject;
        Debug.Log(target.transform.name);
        Health hit = target.GetComponent<Health>();
        Shh shh = target.GetComponentInChildren<Shh>();
        
		if (shh != null)
        {
            _speed *= -2;
            _damage *= 3;
            _damage /= 2;
            gameObject.layer = LayerMask.NameToLayer("PlayerProjectiles");
			return;
        }
		
		if (hit != null)
        {
            hit.Value -= _damage;
            var pm = target.GetComponent<Playermovement>();
            if (pm == null)
                target.transform.position += transform.right * Time.deltaTime * _speed * 2; //knockback, can delete
            else 
                pm.KnockBack(transform.right, _speed * 2);
        }
        
        Destroy(gameObject);
    }
}
