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

    private bool _isAttacking = false;
    
    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Start()
    {
//        _health.HealthListener += () => Debug.Log(_health.Value);
        _startHealth = _health.Value;

    }

    public void BeginAttack()
    {
        StartCoroutine(Combat());
    }


    [SerializeField] private float _speed = 5;
    public float Speed => _speed * _health.Value / _startHealth;

    private Vector2 _towardPlayer => ((Vector2)(_player.position - transform.position)).normalized;
//    enum Phase { }
    

    IEnumerator Combat()
    {
        Coroutine moveTowardsPlayer = StartCoroutine(MoveTowardsPlayer());
        Coroutine CryRoutine;
        while (true)
        {
            if (!_isAttacking && ((Vector2) _player.position - (Vector2) transform.position).magnitude < 2)
            {
                Debug.Log("MELEE");
                StartCoroutine(Melee(5));
            }
            else if (!_isAttacking && _health.Value <= 7 * _startHealth / 8 )
            {
                Debug.Log("Start crying bois");
                CryRoutine = StartCoroutine(CryBurst( (int) (10 * _startHealth / _health.Value), 
                    (_health.Value) / _startHealth * 3, // max cooldown is the number 
                    .05f,
                    (int) (10 * _startHealth / _health.Value)));
            }
            
           
            yield return null;
        }
    }

    private IEnumerator Melee(float damage, float attackspeed = .2f, float cooldown = 1f)
    {
        _isAttacking = true;

        yield return new WaitForSeconds(attackspeed);
        _player.GetComponent<Health>().Value -= damage;
        _player.GetComponent<Playermovement>().KnockBack(_towardPlayer, damage * 2);
        yield return new WaitForSeconds(cooldown);
        _isAttacking = false;
    }

    IEnumerator MoveTowardsPlayer()
    {
        while (true)
        {
            Vector2 toPlayer = (Vector2) transform.position + (Speed * _towardPlayer) * Time.deltaTime;
            Vector2 directPlayer = (Vector2)(_player.position - transform.position);

            transform.position = (directPlayer.magnitude > toPlayer.magnitude) ? directPlayer : toPlayer;
            yield return null;
        }
    }

    IEnumerator CryBurst(int tearAmount,float cooldown, float speed = .05f, float angleVariance = 5)
    {
        _isAttacking = true;
        
        Debug.Log("tear amount " + tearAmount + " cooldown " + cooldown + " angle " + angleVariance);
        for (int i = 0; i < tearAmount; i++)
        {
            float angle =  (2 * Random.value - 1) * angleVariance + 90;
            Debug.Log("SHOOT");
            Instantiate(_projectile, transform.position, Quaternion.LookRotation(Vector3.forward, _towardPlayer.Rotate(angle)));
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(cooldown);
        _isAttacking = false;
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
