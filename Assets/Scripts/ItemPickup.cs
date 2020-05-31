using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public AudioClip clip;
    public float damageIncrease;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.GetComponent<PlayerMovement>();
        
        if(player != null)
        {
            player.animator.SetBool("hasSword", true);
            player.hasSword = true;
            player.damage += damageIncrease;
            AudioManager.Instance.Play(clip, player.transform, 0.6f);
            Destroy(gameObject);
        }
    }
}
