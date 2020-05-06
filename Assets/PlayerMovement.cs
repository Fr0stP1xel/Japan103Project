using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Rigidbody2D rigidBody;
    private float horizontalMove;
    public float runSpeed;
    private float verticalMove;
    private bool jump;
    public AudioClip jumpAudio;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        runSpeed = 25f;
        horizontalMove = 0f;
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
}
