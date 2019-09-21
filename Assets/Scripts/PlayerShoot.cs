using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Playermovement))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    private Playermovement _pm;
    
    void Awake()
    {
        _pm = GetComponent<Playermovement>();
    }
    void Update()
    {
        float fire = Input.GetAxis("Fire1");
        if(fire > float.Epsilon)
        {
            if (_bullet != null) Instantiate(_bullet, transform.position, Quaternion.LookRotation(Vector3.forward ,_pm.Direction));
            else Debug.LogError("No bullet assigned to PlayerShoot");
        }
        Debug.DrawLine(transform.position, (Vector2)transform.position + _pm.Direction * 2);

    }
}
