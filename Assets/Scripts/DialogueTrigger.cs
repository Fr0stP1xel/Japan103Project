using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public int count;
    public bool summonItem = false;
    public string itemTag = "";

    public void TriggerDialogue()
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.count = count;
        dialogueManager.summonItem = summonItem;
        dialogueManager.itemTag = itemTag;
        dialogueManager.StartDialogue(dialogue);

    }
}
