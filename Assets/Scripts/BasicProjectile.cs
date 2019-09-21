using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour

{
    [SerializeField] private float _speed = 5;
    [Tooltip("Time in secs until bullet disappears")]
    [SerializeField] private float _lifespan = 3;

    // Update is called once per frame
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
        Destroy(gameObject);
    }
}
