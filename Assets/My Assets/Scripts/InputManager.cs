using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitDiet
{
    public class InputManager : MonoBehaviour
    {
        [Header("References")]
        private PlayerAction inputActions;

        [Header("Input Parameters")]
        public Vector2 movementInput;
        public bool canMove;

        private void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerAction();
            }
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        public void HandleAllInputs()
        {
            if (canMove)
                movementInput = inputActions.Player.Move.ReadValue<Vector2>();
        }
    }
}

