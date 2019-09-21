using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health _health;
    private float _startWidth;
    private float _startHealth;
    private void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        _startWidth = rt.rect.width;
        _startHealth = _health.Value;
        _health.HealthListener += () =>
        {
            rt.sizeDelta = new Vector2(_startWidth * _health.Value / _startHealth, rt.sizeDelta.y);
        };
    }
}
