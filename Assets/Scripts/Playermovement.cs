using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField] float _speed = 5f;

    private Vector2 _prevPos;
    private Vector2 _velocity;
    public Vector2 Velocity => _velocity;
    public Vector2 Direction { get; private set; }

    void FixedUpdate()
    {
        float vert = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        Vector2 newPos = (Vector2)transform.position + new Vector2(
            _speed * hor * Time.deltaTime,
            _speed * vert * Time.deltaTime
        );

        _prevPos = transform.position;
        transform.position = newPos;
        _velocity = (newPos - _prevPos) / Time.deltaTime;

        if (_velocity.magnitude > float.Epsilon) Direction = _velocity.normalized;
    }
}
