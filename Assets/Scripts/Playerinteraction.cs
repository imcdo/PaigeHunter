using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Playerinteraction : MonoBehaviour
{

    [SerializeField] private float _radiusint = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Dialogue()
    {
        Transform nearest = null;
        float nearDist = 9999f;

        Collider[] colliders = Physics.OverlapSphere(transform.position, _radiusint);
        var characters = from collider in colliders
                         where collider.GetComponent<CharacterInteraction>() != null
                         select collider.GetComponent<CharacterInteraction>();

        //characters.Min(char1=> Vector2.Distance(transform.position, char1.transform.position));
        foreach (CharacterInteraction cr in characters)
        {
            float thisDist = (transform.position - cr.transform.position).sqrMagnitude;
            if (thisDist < nearDist)
            {
                nearDist = thisDist;
                nearest = cr.transform;
            }
        }

        if (nearest != null)
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Fire2") > float.Epsilon)
        {
            Dialogue();
        }
    }
}
