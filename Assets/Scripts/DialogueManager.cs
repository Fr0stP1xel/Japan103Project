using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    Queue<string> sentences;

    public Text nameText;
    public Text dialogueText;
    public Canvas canvas;
    public string speaker;
    public string player;
    public int count;
    public bool summonItem = false;
    public string itemTag = "";

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        canvas.enabled = false;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        canvas.enabled = true;

        speaker = dialogue.name;
        nameText.text = speaker;
        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            count++;
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

        if (count % 2 == 0)
        {
            nameText.text = player;
        }
        else
        {
            nameText.text = speaker;
        }
        count++;

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        canvas.enabled = false;
        if (summonItem)
        {
            GameObject.FindGameObjectWithTag(itemTag).GetComponent<SpriteRenderer>().enabled = true;
        }
    }

}
