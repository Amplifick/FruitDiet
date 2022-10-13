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

        [Header("Keys Pressed")]
        public bool wPressed, aPressed, sPressed, dPressed;

        private void Awake()
        {
            uIManager = GameManager.Instance.uiInstance;
            image = GetComponent<Image>();
            leanToggle = GetComponent<LeanToggle>();
        }

        private void Update()
        {
            #region Handling the Keys actions

            if(GameManager.Instance.stateInstance.currentState == StateOfGame.OnTutorial)
            {
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
            }

            #endregion
        }

        #region Keys Pressed
        private bool WPressed()
        {
            if (GameManager.Instance.inputInstance.movementInput.y > 0)
            {
                wPressed = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool SPressed()
        {
            if (GameManager.Instance.inputInstance.movementInput.y < 0)
            {
                sPressed = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool DPressed()
        {
            if (GameManager.Instance.inputInstance.movementInput.x > 0)
            {
                dPressed = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool APressed()
        {
            if (GameManager.Instance.inputInstance.movementInput.x < 0)
            {
                aPressed = true;
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

