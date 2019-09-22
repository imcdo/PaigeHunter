using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Playermovement))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    private Playermovement _pm;
    [SerializeField] private float _cooldown = .25f;
    private float _elapsed = 0;

    private void Start()
    {
        Health h = GetComponent<Health>();
        h.HealthListener += () => Debug.Log(h.Value);
    }

    void Awake()
    {
        _pm = GetComponent<Playermovement>();
    }
    void Update()
    {
        _elapsed += Time.deltaTime;
        if (_elapsed > _cooldown)
        {
            float fire = Input.GetAxis("Fire1");
            if (fire > float.Epsilon)
            {
                if (_bullet != null)
                {
                    _elapsed = 0;
                    Instantiate(_bullet, transform.position, Quaternion.FromToRotation(Vector3.right, _pm.Direction));
                }
                else
                {
                    Debug.LogError("No bullet assigned to PlayerShoot");
                }
            }
            Debug.DrawLine(transform.position, (Vector2)transform.position + _pm.Direction * 2);
        }
//<<<<<<< Updated upstream
//=======
        Debug.DrawLine(transform.position, (Vector2)transform.position + _pm.Direction * 2);
        
   

//>>>>>>> Stashed changes
    }
}
