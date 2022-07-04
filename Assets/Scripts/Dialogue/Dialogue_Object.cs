using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Object : MonoBehaviour
{

    public DialogueTrigger trigger;
    private bool hasTalked;
    [NonReorderable]
    public List<Dialogue> firstDialogue;
    [NonReorderable]
    public List<Dialogue> repeatDialogue;
    

    // Start is called before the first frame update
    void Start()
    {
        hasTalked = false;
    }
    

    private void OnTriggerEnter2D(Collider2D other) {        
        if(other.CompareTag("Player")){
           
            trigger.dialogues = repeatDialogue;
            if(!hasTalked){
            hasTalked = true;
            trigger.dialogues = firstDialogue;
            }
            Debug.Log("Text Trigger");
            trigger.TriggerDialogue();

        }
    }

}
