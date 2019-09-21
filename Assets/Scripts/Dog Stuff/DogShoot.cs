using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _parent;
    [SerializeField] private float _delay = 1.5f;
    [SerializeField] private GameObject _target;
    private float _timer = 0;



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
