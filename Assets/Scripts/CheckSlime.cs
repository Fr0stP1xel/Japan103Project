using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSlime : MonoBehaviour
{
    public int slimeCount = 2;
    public string slimeTag;
    public bool summonBigBoi = true;
    // Update is called once per frame
    void Update()
    {
        slimeCount = GameObject.FindGameObjectsWithTag(slimeTag).Length;
        if(slimeCount == 0)
        {
            GetComponent<DialogueTrigger>().TriggerDialogue();
            if (summonBigBoi)
            {
                GameObject.FindGameObjectWithTag("BigBoi").GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
