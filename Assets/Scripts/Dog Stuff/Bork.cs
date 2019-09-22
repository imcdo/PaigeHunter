using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bork : MonoBehaviour

{
    [SerializeField] private float _speed = 5;
    [Tooltip("Time in secs until bork disappears")]
    [SerializeField] private float _lifespan = 3;
    [SerializeField] private float _damage = 10;



    void Update()
    {
        Debug.Log("Started bork!");
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
        // Playermovement p = target.GetComponent<Playermovement>();
        // Debug.Log(p.Speed);
        /*Velocity hit = target.GetComponent<Health>();
        if (hit != null)
        {
            target.transform.position += transform.right * Time.deltaTime * _speed * 2; //knockback, can delete
        }
        */
        Destroy(gameObject);
        
    }
}
