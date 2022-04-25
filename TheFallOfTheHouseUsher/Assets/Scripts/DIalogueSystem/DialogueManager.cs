using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Animator anim;
    private Queue<string> sentences;
    public Text NPCName;
    public Text dialogue;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartDialogue(Dialogue dialogue)
    {
        anim.SetBool("IsOpen", true);
        NPCName.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            FindObjectOfType<NPCInteraction>().isDialogueTrigger = false;
            anim.SetBool("IsOpen", false);
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence)); 
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogue.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogue.text += letter;
            yield return new WaitForSeconds(.1f);
        }
    }

}
