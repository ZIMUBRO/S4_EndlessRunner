using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float jumpForce;

    [SerializeField]
    bool isGround = false;

    [SerializeField]
    Animator playerAnim;

    [SerializeField]
    bool AnimIsJump;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        //AnimIsJump = playerAnim.GetBool("isJump");
        AnimIsJump = false;

    }

    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (isGround == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Stamina.Instance._slider.value >= Stamina.Instance._staminaUse)
            {
                rb.AddForce(new Vector2(0, jumpForce));
                isGround = false;
                AnimIsJump = true;
                playerAnim.SetBool("isJump", true);

                //Using stamina
                Stamina.Instance.UsingStamina(Stamina.Instance._staminaUse);


            }
            else
            {
                playerAnim.SetBool("isJump", false);
                AnimIsJump = false;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag("OC_wall"))
        {
            isGround = true;
        }
    }
}
