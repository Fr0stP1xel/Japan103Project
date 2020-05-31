using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Rigidbody2D rigidBody;
    public AudioClip jumpAudio;
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    private bool jump;
    public bool hasSword;

    private float verticalMove;
    private float horizontalMove;
    public float runSpeed;
    public float attackRange;
    public float damage;
    public float attackRate;
    private float nextAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        runSpeed = 25f;
        damage = 10f;
        attackRate = 3f;
        attackRange = 0.5f;
        nextAttackTime = 0f;
        horizontalMove = 0f;
        hasSword = false;
        jump = false;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = rigidBody.velocity.y;
        animator.SetFloat("horizontalSpeed", Mathf.Abs(horizontalMove));
        animator.SetFloat("verticalSpeed", verticalMove);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jump", true);
            AudioManager.Instance.Play(jumpAudio, transform);
        }

        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
                nextAttackTime = Time.time + (1f / attackRate);
            }
        }
        
    }

    void FixedUpdate()
    {
        // Character Movement
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }

    public void isLanding()
    {
        animator.SetBool("Jump", false);
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
            if(enemy != null)
            {
                enemy.GetComponent<SlimeController>().TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
