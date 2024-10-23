using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class mainc : MonoBehaviour
{
    
    public float speed;
    private float JumpForce;
    float move;

    private Rigidbody2D rigid;

    bool FacingRight = true;

    bool isGrounded;
    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask WhatGround;

    public int ExtraJump;
    //กระโดดได้กี่ครั้ง
    public int ExtraJumpValue;
    // Start is called before the first frame update
    void Start()
    {
        ExtraJump = ExtraJumpValue;
       rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isGrounded == true)
        {
            ExtraJumpValue = ExtraJump;
        }
        if (Input.GetKeyDown(KeyCode.Space) && ExtraJump > 0)
        {
            rigid.velocity = Vector2.up * JumpForce;
            ExtraJump--;
        }

        if (Input.GetKeyDown(KeyCode.Space) && ExtraJump == 0&& isGrounded == true)
        {
            rigid.velocity = Vector2.up * JumpForce;
            ExtraJumpValue = ExtraJump;
        }
    }

    
    // Update is called once per frame
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, WhatGround);
        
        move = Input.GetAxis("Horizontal");

        rigid.velocity = new Vector2(move * speed * Time.fixedDeltaTime, rigid.velocity.y);

        if (FacingRight == false && move > 0)
        {
            Flip();
        }
        if (FacingRight == true && move < 0)
        {
            Flip();
        }
    }

    public void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }    
}
