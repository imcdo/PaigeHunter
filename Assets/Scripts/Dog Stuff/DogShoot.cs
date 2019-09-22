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
                float rot = 10;
                Vector2 targetDirection = (_target.transform.position - transform.position).normalized;
                float rad = Mathf.Deg2Rad * rot;
                Vector2 b1 = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)) + targetDirection;
                Vector2 b2 = new Vector2(Mathf.Cos(-rad), Mathf.Sin(-rad)) + targetDirection;

                Instantiate(_bullet, transform.position, Quaternion.FromToRotation(Vector3.right, targetDirection));
                Instantiate(_bullet, transform.position, Quaternion.FromToRotation(Vector3.right, b1));
                Instantiate(_bullet, transform.position, Quaternion.FromToRotation(Vector3.right, b2));
            }
            _timer = 0;
        }
    }
}
        