using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;
    public TextMeshProUGUI dialogueText;

    public GameObject tutorialCanvas;
    public GameObject talk;

    public AudioSource audioSource;

    void Awake()
    {
       sentences = new Queue<string>();
       tutorialCanvas.SetActive(false);
       talk.SetActive(true);
       audioSource = GetComponent<AudioSource>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log(dialogue.sentences[0]);

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        audioSource.Play();
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
        audioSource.Stop();
    }

    public void EndDialogue()
    {
        tutorialCanvas.SetActive(true);
        talk.SetActive(false);
       
    }
}
