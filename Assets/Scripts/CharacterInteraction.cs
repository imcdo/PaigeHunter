using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;   

public enum Characters
{
    Paige, Dog, Onion
}

[RequireComponent(typeof(DialogueTrigger))]
public class CharacterInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    private DialogueTrigger _dt;
    public DialogueTrigger DialogueTrigger => _dt;
    public List<Characters> speakers;

   
    void Start()
    {
        _dt = GetComponent<DialogueTrigger>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
