using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public AudioClip clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterController2D player = collision.GetComponent<CharacterController2D>();
        
        if(player != null)
        {
            if (Input.GetButtonDown("Interact"))
            {
                AudioManager.Instance.Play(clip, player.transform);
                Destroy(gameObject);
            }
            
        }
    }
}
