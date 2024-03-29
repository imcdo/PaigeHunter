﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingProjectile : MonoBehaviour

{
    [SerializeField] private float _speed = 5;
    [Tooltip("Time in secs until bullet disappears")]
    [SerializeField] private float _lifespan = 3;
    [SerializeField] private float _damage = 10;
    private Vector3 _travelDirection;

    void Awake()
    {
        _travelDirection = transform.right;
    }

    void Update()
    {
        _lifespan -= Time.deltaTime;

        if (_lifespan > 0)
        {
            transform.position += _travelDirection * Time.deltaTime * _speed;
            transform.Rotate(0, 0, 10, Space.Self);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject target = collision.gameObject;
        Health hit = target.GetComponent<Health>();
        SpriteRenderer s = target.GetComponent<SpriteRenderer>();
        if (hit != null)
        {
            hit.Value -= _damage;
            target.transform.position += _travelDirection * Time.deltaTime * _speed * 2; //knockback, can delete
        }
        
        Destroy(gameObject);
        
    }

    IEnumerator FlashDamage(SpriteRenderer s, Health hit)
    {
        if (hit != null)
        {
            transform.localScale = new Vector3(0, 0, 0);
            s.color = new Color(1, 0, 0, 1);
            yield return new WaitForSeconds(.2f);
            s.color = new Color(1, 1, 1, 1);
        }

    }

}
