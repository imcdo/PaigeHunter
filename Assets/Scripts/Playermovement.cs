using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    private Animator _myAnimator;
    enum Directions { East, NorthEast, North, NorthWest, West, SouthWest, South, SouthEast}
    [SerializeField] float _speed = 5f;

    private Vector2 _prevPos;
    private Vector2 _velocity;
    public Vector2 Velocity => _velocity;
    public Vector2 Direction { get; private set; }

    private void Awake()
    {
        _myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Directions dir;
        /*      if (Mathf.Abs(Direction.x) > float.Epsilon && Mathf.Abs(Direction.y) <= float.Epsilon)
                  dir = (Direction.x < 0) ? Directions.West : Directions.East;
              else if (Mathf.Abs(Direction.y) > float.Epsilon && Mathf.Abs(Direction.x) <= float.Epsilon)
                  dir = (Direction.y < 0) ? Directions.South : Directions.North;
              else
              {
                  if (Direction.x > 0 && Direction.y > 0)
                      dir = Directions.NorthEast;
                  else if (Direction.x > 0)
                      dir = Directions.SouthEast;
                  else if (Direction.y < 0)
                      dir = Directions.SouthWest;
                  else
                      dir = Directions.NorthWest;
              } */
        float x = Direction.x;
        float y = Direction.y;
        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x > Mathf.Epsilon)
                dir = Directions.East;
            else
                dir = Directions.West;
        } else
        {
            if (y > Mathf.Epsilon)
                dir = Directions.North;
            else
                dir = Directions.South;
        }

        _myAnimator?.SetInteger("Direction", (int) dir);
        _myAnimator?.SetFloat("Speed", _velocity.magnitude);
    }

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
