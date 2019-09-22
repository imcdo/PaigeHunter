using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        images = new Queue<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
       
        //queue up images and sentences given for character into internal variables to be dequed.
        foreach(Sprite image in dialogue.images)
        {
            images.Enqueue(image);
        }

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
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
    }
}
