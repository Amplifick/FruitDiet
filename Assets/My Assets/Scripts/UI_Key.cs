using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;

namespace FruitDiet
{
    public class UI_Key : MonoBehaviour
    {
        public enum Key { W, A, S, D };

        private UIManager uIManager;

        [Header("Setting's")]
        private Image image;
        private LeanToggle leanToggle;
        public Key typeOfKey;
        public Sprite unpressedSprite;
        public Sprite pressedSprite;
        public GameObject outlineVFX;

        private void Awake()
        {
            uIManager = FindObjectOfType<UIManager>();
            image = GetComponent<Image>();
            leanToggle = GetComponent<LeanToggle>();
        }

        private void Update()
        {
            #region Handling the Keys actions
            if ((typeOfKey == Key.W))
            {
                if (WPressed())
                    uIManager.KeyPressed(image, pressedSprite, outlineVFX, leanToggle);
                else
                    uIManager.KeyReleased(image, unpressedSprite, outlineVFX, leanToggle);
            }

            if ((typeOfKey == Key.A))
            {
                if (APressed())
                    uIManager.KeyPressed(image, pressedSprite, outlineVFX, leanToggle);
                else
                    uIManager.KeyReleased(image, unpressedSprite, outlineVFX, leanToggle);
            }

            if ((typeOfKey == Key.S))
            {
                if (SPressed())
                    uIManager.KeyPressed(image, pressedSprite, outlineVFX, leanToggle);
                else
                    uIManager.KeyReleased(image, unpressedSprite, outlineVFX, leanToggle);
            }

            if ((typeOfKey == Key.D))
            {
                if (DPressed())
                    uIManager.KeyPressed(image, pressedSprite, outlineVFX, leanToggle);
                else
                    uIManager.KeyReleased(image, unpressedSprite, outlineVFX, leanToggle);
            }
            #endregion
        }

        #region Keys Pressed
        private bool WPressed()
        {
            if (uIManager.GetComponent<GameManager>().GetComponent<InputManager>().movementInput.y > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool SPressed()
        {
            if (uIManager.GetComponent<GameManager>().GetComponent<InputManager>().movementInput.y < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool DPressed()
        {
            if (uIManager.GetComponent<GameManager>().GetComponent<InputManager>().movementInput.x > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool APressed()
        {
            if (uIManager.GetComponent<GameManager>().GetComponent<InputManager>().movementInput.x < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}

