﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Image prof;

    public Animator animator;

    private Queue<string> sentences;
    private Queue<Sprite> images;
    private Queue<string> names;

    private Onion o;
    private DogBehavior dog;
    private Playermovement player;

    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        images = new Queue<Sprite>();
        names = new Queue<string>();

        o = FindObjectOfType<Onion>();
        dog = FindObjectOfType<DogBehavior>();
        player = FindObjectOfType<Playermovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        //queue up images and sentences given for character into internal variables to be dequed.
        sentences.Clear();

        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            images.Enqueue(dialogue.images[i]);
            sentences.Enqueue(dialogue.sentences[i]);
            names.Enqueue(dialogue.names[i]);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //if none left, end dialogue
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        prof.sprite = images.Dequeue();
        nameText.text = names.Dequeue();
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        
        animator.SetBool("IsOpen", false);
        var on = FindObjectOfType<Onion>();
        
        if (Vector2.Distance(on.transform.position,player. transform.position) < 5)  
            on.BeginAttack();   
        if (Vector2.Distance(on.transform.position,player. transform.position) < 5)  
            dog.BeginAttack();   
    }
}
