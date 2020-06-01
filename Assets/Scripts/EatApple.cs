using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatApple : MonoBehaviour
{

    public AudioClip clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.Play(clip, collision.GetComponent<PlayerMovement>().transform, 0.4f);
            collision.GetComponent<PlayerMovement>().apples += 1;
            Destroy(gameObject);
        }
    }
}
