using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public AudioClip clip;
    public float damageIncrease;
    public bool triggerDialogue;
    public bool playAudio = true;
    public string dialogueTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.GetComponent<PlayerMovement>();
        
        if(player != null)
        {
            player.animator.SetBool("hasSword", true);
            player.hasSword = true;
            player.damage += damageIncrease;
            if (playAudio)
            {
                AudioManager.Instance.Play(clip, player.transform, 0.6f);

            }

            if (triggerDialogue)
            {
                GameObject.FindGameObjectWithTag(dialogueTag).GetComponent<DialogueTrigger>().TriggerDialogue();
            }

            Destroy(gameObject);
        }
    }
}
