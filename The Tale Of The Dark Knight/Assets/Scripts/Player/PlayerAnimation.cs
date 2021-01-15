using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
    }

    void CheckMovement()
    {
        if (rb.velocity.x > 0 || rb.velocity.x < 0)
        {
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        }

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Jumping");
        }
    }
}
