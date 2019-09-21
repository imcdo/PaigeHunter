using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _delay = .5f;
    private float _timer = 0;
    [SerializeField] private GameObject _target;

    

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _delay)
        {
            if (_bullet != null && _target != null)
            {
                Vector3 targetDirection = _target.transform.position - transform.position;
                Instantiate(_bullet, transform.position, Quaternion.FromToRotation(Vector3.right, targetDirection));
            }
            _timer = 0;
        }
    }
}
