using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Image portrait;

    public GameObject nextButton;

    public  Animator animator;

    private Queue<Dialogue> dialogues = new Queue<Dialogue>();
    private Queue<string> sentences;

    public void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialogue(List<Dialogue> dialogueList){
        // Poner los dialogos en una fila
        foreach(Dialogue dialogue in dialogueList){
            dialogues.Enqueue(dialogue);
        }
        // Prepararse para el display
        animator.SetBool("isActive", true);
        ShowDialogues();
    }

    public void ShowDialogues(){
        Dialogue dialogue = dialogues.Dequeue();
        sentences.Clear();
        // Set Variables for Dialogue Box
        nameText.text = dialogue.name;
        portrait.sprite = dialogue.portrait;
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
        if(dialogues.Count != 0){
            ShowDialogues();
        }else{
            animator.SetBool("isActive", false);
            dialogues.Clear();
        }
        
    }
    

}
