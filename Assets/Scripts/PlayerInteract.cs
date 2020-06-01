using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    bool inRange = false;
    public int repeatable = 1;
    public int increment = 0;
    public string dialogueTag;

    private void Update()
    {
        if (repeatable == 1 && inRange && Input.GetButtonDown("Interact"))
        {
            repeatable += increment;
            inRange = false;
            GameObject.FindGameObjectWithTag(dialogueTag).GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }
}
