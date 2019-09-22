using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Onion : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _projectile;
    private Health _health;
    private float _startHealth;

    private bool _isCrying = false;
    
    private void Awake()
    {
        _health = GetComponent<Health>();
        _startHealth = _health.Value;
    }

    private void Start()
    {
        _health.HealthListener += () => Debug.Log(_health.Value);
    }


    [SerializeField] private float _speed = 5;
    public float Speed => _speed * _health.Value / _startHealth;

    private Vector2 _towardPlayer => ((Vector2)(_player.position - transform.position)).normalized;
//    enum Phase { }
    

    IEnumerator StartCombat()
    {
        Coroutine moveTowardsPlayer = StartCoroutine(MoveTowardsPlayer());

        Coroutine CryRoutine;
        if (_health.Value <= _startHealth / 2)
        {
           CryRoutine = StartCoroutine(CryBurst((int) (_startHealth / _health.Value), ( _health.Value) ));
           
        }

        while (true)
        {
            if (!_isCrying) CryRoutine = StartCoroutine(CryBurst((int) (_startHealth / _health.Value), (_health.Value)));
        }
        
        yield return null;
    }

    IEnumerator MoveTowardsPlayer()
    {
        while (true)
        {
            transform.position += (Vector3)(Speed * _towardPlayer);
            yield return null;
        }
    }

    IEnumerator CryBurst(int tearAmount,float cooldown, float speed = .2f, float angleVariance = 5)
    {
        _isCrying = true;

        for (int i = 0; i < tearAmount; i++)
        {
            float angle =  (2 * Random.value - 1) * angleVariance;
            Instantiate(_projectile, transform.position, Quaternion.LookRotation(Vector3.forward, _towardPlayer.Rotate(angle)));
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(cooldown);
        _isCrying = false;
    }
}

public static class Vector2Extension
{

    public static Vector2 Rotate(this Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }
}
