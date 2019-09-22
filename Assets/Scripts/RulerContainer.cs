using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerContainer : MonoBehaviour
{
    private Playermovement _pm;

    void Start()
    {
        _pm = transform.parent.GetComponent<Playermovement>();
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, -1*_pm.Direction);
    }
}
