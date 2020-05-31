using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlimeController : MonoBehaviour
{

    float maxHealth;
    float currentHealth;
    public Animator animator;
    public bool moveRight;
    public float speed;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 20;
        speed = 0.7f;
        currentHealth = maxHealth;
    }

    private void Update()
    {

        if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            sprite.flipX = true;
        } else {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            sprite.flipX = false;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDead", true);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Turn"))
        {
            moveRight = !moveRight;
        }
    }
}
