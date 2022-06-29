using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Dialogues")]
    [NonReorderable]
    public List<Dialogue> dialogues;

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogues);
    }

}
