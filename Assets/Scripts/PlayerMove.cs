﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    // Start is called before the first frame update

    float horizontal_m=0f;
    float run_speed = 40f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontal_m = Input.GetAxisRaw("Horizontal") * run_speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontal_m));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetFloat("Alt_jump", 1f);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetFloat("Alt_jump", 0f);
    }

    public void OnCrouch(bool crouching)
    {
        animator.SetBool("Alt_crouch", crouching);
    }

    private void FixedUpdate()
    {
        //Move Character 
        controller.Move(horizontal_m *Time.fixedDeltaTime,crouch,jump);
        jump = false;
    }
}
