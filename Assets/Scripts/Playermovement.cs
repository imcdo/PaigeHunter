using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField] float _speed = 5f;

    private Vector2 _prevpos;
    private Vector2 _velocity;

    void Update()
    {
        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        Vector2 newPos = (Vector2)transform.position + new Vector2(
            _speed * hor * Time.deltaTime,
            _speed * vert * Time.deltaTime
        );

        _prevpos = transform.position;
        transform.position = newPos;
        _velocity = (newPos - _prevpos) / Time.deltaTime;

        Debug.Log(_velocity);
    }
}
