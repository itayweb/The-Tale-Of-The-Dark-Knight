using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMovement pm;
    private Rigidbody2D rb;
    private Animator anim;
    private int attackState;

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        attackState = GetComponent<PlayerCombatSystem>().AttackStateShuffle();
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

        if (!pm.IsPlayerOnGround())
        {
            anim.SetBool("IsJumping", true);
        }

        else
        {
            anim.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.F)){
            switch(attackState){
                case 1:
                    anim.SetTrigger("Attack1");                
                    break;
                case 2:
                    anim.SetTrigger("Attack2");
                    break;
                default:
                    break;
            }
        }
    }
}
