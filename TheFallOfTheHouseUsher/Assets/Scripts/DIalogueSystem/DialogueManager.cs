using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;

    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

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

            animator.SetBool("IsOpen", false);

            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        FindObjectOfType<NPCInteraction>().audioSource.Play();

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.1f);
        }

        FindObjectOfType<NPCInteraction>().audioSource.Stop();
    }

    
}
