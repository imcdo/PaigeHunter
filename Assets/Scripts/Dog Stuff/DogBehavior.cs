using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Health))]

public class DogBehavior : MonoBehaviour
{
    [SerializeField] private Transform _playerTrans;
    [SerializeField] private GameObject _beaker;
    [SerializeField] private GameObject _bork;
    [SerializeField] private GameObject _player;
    private Health _health;
    private float _startHealth;
    private int _phase; // 0 - pre-fight, 1 - fight w/ beakers, 2 - minions, 3 - ded


    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Start()
    {

        _phase = 0;
        _startHealth = _health.Value;
        StartCoroutine(Attack(2f));

        //StartCoroutine(BeakerBurst(.5f));
        //StartCoroutine(Bork());
        /*Health h = GetComponent<Health>();
        h.HealthListener += () =>
        {
            if(h.Valu)
            if (h.Value < 50f)
            {
                _phase = 2;
                StartCoroutine(BeakerBurst(1.6f));
            }
        };*/

    }

    [SerializeField] private float _speed = 5;
    private Vector2 _towardPlayer => ((Vector2)(_playerTrans.position - transform.position)).normalized;
    private bool _canAttack;


    IEnumerator Attack(float beakerCD)
    {
        _canAttack = true;
        Debug.Log("attack");
        StartCoroutine(MoveTowardsPlayer());
        while (true)
        {

            if (_canAttack && ((Vector2)_playerTrans.position - (Vector2)transform.position).magnitude > 6)
            {
                _canAttack = false;
                StartCoroutine(Bork());
            } else if (_canAttack)
            {
                _canAttack = false;
                StartCoroutine(BeakerBurst(beakerCD));
            }
            yield return null;
        }
    }

    IEnumerator BeakerBurst(float cooldown)
    {
        if (_beaker != null && _player != null)
        {
            Vector3 targetDirection1 = _playerTrans.position - transform.position;
            Instantiate(_beaker, transform.position, Quaternion.FromToRotation(Vector3.right, targetDirection1));
            if (_health <= _startHealth / 2)
            {
                Debug.Log("Dog phase 2");
                Vector3 targetDirection2 = new Vector3(targetDirection1.x, targetDirection1.y, 0);
                Vector2Extension.Rotate((Vector2) targetDirection2, 15);
                Instantiate(_beaker, transform.position, Quaternion.FromToRotation(Vector3.right, targetDirection2));
            }

            yield return new WaitForSeconds(cooldown);
            _canAttack = true;
        }
    }



    IEnumerator Bork()
    {
        Vector3 targetDirection1 = _playerTrans.position - transform.position;
        Instantiate(_bork, transform.position, Quaternion.FromToRotation(Vector3.right, targetDirection1));
        yield return new WaitForSeconds(Random.Range(4, 6));
        _canAttack = true;
    }

    IEnumerator MoveTowardsPlayer()
    {
        while (true)
        {
            Vector2 toPlayer = (Vector2)transform.position + (_speed * _towardPlayer) * Time.deltaTime;
            transform.position = toPlayer;
            yield return null;
        }
    }

    public void BeginAttack()
    {
        _phase++;
    }

}


