using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitDiet
{
    public class Player : CharacterController
    {
        [Header("References")]


        [Header("Physic's & Transform")]
        public Rigidbody2D rb;
        public Transform groundCheck;
        public LayerMask groundLayer;

        [Header("Movement Setting's")]
        public float horizontal;
        public float vertical;
        public float speed;
        public float jumpingPower;
        public bool isFacingRight = true;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            HandleMovementAndJumping();

            anim.SetFloat("Speed", Mathf.Abs(horizontal));

            if (!isFacingRight && horizontal > 0f)
            {
                Flip();
            }
            else if (isFacingRight && horizontal < 0f)
            {
                Flip();
            }
        }

        public void HandleMovementAndJumping()
        {
            Movement();
            Jump();
        }

        private void Movement()
        {
            if (GameManager.Instance.stateInstance.currentState == StateOfGame.OnGame)
            {
                horizontal = GameManager.Instance.inputInstance.movementInput.x;
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }
            else if (GameManager.Instance.stateInstance.currentState == StateOfGame.OnTutorial)
            {
                horizontal = GameManager.Instance.inputInstance.movementInput.x;
            }

        }

        private void Jump()
        {
            vertical = GameManager.Instance.inputInstance.movementInput.y;

            if (vertical > 0 && isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
        }

        private bool isGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }

        private void Flip()
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }


    }
}

