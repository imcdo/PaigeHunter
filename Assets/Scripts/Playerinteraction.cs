using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Playerinteraction : MonoBehaviour
{

    [SerializeField] private float _radiusint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Dialogue()
    {
        CharacterInteraction nearest = null;
        float nearDist = 9999f;


        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radiusint);
        Debug.Log(colliders.Length);
        var characters = from collider in colliders
                         where collider.GetComponent<CharacterInteraction>() != null
                         select collider.GetComponent<CharacterInteraction>();

        Debug.Log(characters.Count());
        //characters.Min(char1=> Vector2.Distance(transform.position, char1.transform.position));
        foreach (CharacterInteraction cr in characters)
        {
            float thisDist = (transform.position - cr.transform.position).sqrMagnitude;
            if (thisDist < nearDist)
            {
                nearDist = thisDist;
                nearest = cr;
            }
            Debug.Log(nearDist);
        }

        if (nearest != null)
        {
            nearest.DialogueTrigger.TriggerDialogue();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("x"))
        {
            Dialogue();
        }

        Vector3 x = new Vector3(_radiusint, _radiusint, 0);
        Debug.DrawLine(transform.position, transform.position + x, Color.blue );
    }
}
