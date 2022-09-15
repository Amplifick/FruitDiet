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

            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

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

        private void Movement()
        {
            horizontal = GameManager.Instance.inputInstance.movementInput.x;
        }
    }
}

