using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public GameObject nextButton;

    public  Animator animator;

    private Queue<string> sentences;

    public void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){
        animator.SetBool("isActive", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence(){
        nextButton.SetActive(false);
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence){
        dialogueText.text = string.Empty;
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return null;
        }
        nextButton.SetActive(true);
    }

    public void EndDialogue(){
        animator.SetBool("isActive", false);
    }

}
