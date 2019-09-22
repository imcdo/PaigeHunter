using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RenderByY : MonoBehaviour
{
    private SpriteRenderer _sr;

    void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _sr.sortingOrder = -(int)(transform.position.y * 100); // dummy accuracy constant
    }
}
