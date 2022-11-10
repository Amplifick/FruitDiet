using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;

namespace FruitDiet
{
    public class UIManager : MonoBehaviour
    {
        public GameObject currentInterface;
        public void RepeatInteraction(LeanWindow lw)
        {
            StartCoroutine(Leanhandle(lw));
        }

        public void NextInteraction(GameObject nextInteraction)
        {
            currentInterface.SetActive(false);
            currentInterface = nextInteraction;
            currentInterface.SetActive(true);
        }
        private IEnumerator Leanhandle(LeanWindow lw)
        {
            lw.On = false;
            yield return new WaitForSeconds(1f);
            lw.On = true;
        }

        #region Balance Bar Functions

        public void PulseBalanceBar(LeanPulse leanPulse, RectTransform barTransform, float balanceValue)
        {
            leanPulse.Pulse();
            //incline bar
            float incrementRotationRate = 2.7f / 600;
            float rotationValue = incrementRotationRate * balanceValue;
            //Vector3 newRotation = new Vector3(0,0, rotationValue);
            barTransform.rotation = Quaternion.Euler(0,0, rotationValue);
        }
        
        public void UpdateMarkerPosition(RectTransform markerPosition, Vector3 newPosition)
        {
            markerPosition.localPosition = newPosition;
        }

        public void EnableUIElement(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public void DisableUIElement(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        #endregion

        #region Buttons Extra Functions

        public void AddLoadSceneFunctionToButton(LeanButton leanButton, string sceneName)
        {
            leanButton.OnClick.AddListener(() =>
            {
                GameManager.Instance.sceneInstance.LoadScene(sceneName);
            });
        }

        public void EnableUIOnTime(CanvasGroup uiObject, float time)
        {
            StartCoroutine(EnableAfterTime(uiObject,time));
        }

        private IEnumerator EnableAfterTime(CanvasGroup uiObject, float time)
        {
            yield return new WaitForSeconds(time);
            uiObject.alpha = 1;

        }

        public void AddReloadSceneFunctionToButton(LeanButton leanButton)
        {
            leanButton.OnClick.AddListener(() =>
            {
                GameManager.Instance.sceneInstance.ReloadActiveScene();
            });
        }
        public void AddResumeGameFunctionToButton(LeanButton leanButton)
        {
            leanButton.OnClick.AddListener(() =>
            {
                GameManager.Instance.sceneInstance.ResumeGame();
            });
        }

        public void AddReloadSceneAndEnableInputFunctionToButton(LeanButton leanButton)
        {
            leanButton.OnClick.AddListener(() =>
            {
                GameManager.Instance.sceneInstance.ReloadActiveScene();
                GameManager.Instance.inputInstance.canMove = true;
            });
        }

        public void AddPlayOneShotAudioFunctionToButton(LeanButton leanButton, AudioSource source, AudioClip clip)
        {
            leanButton.OnClick.AddListener(() =>
            {
                GameManager.Instance.soundInstance.PlayOneShotAudio(source, clip);
            });
        }

        public void AddChangeStateOfGameFunctionToButton(LeanButton leanButton, StateOfGame newStateOfGame)
        {
            leanButton.OnClick.AddListener(() =>
            {
                GameManager.Instance.stateInstance.ChangeCurrentState(newStateOfGame);
            });
        }


        #endregion

        #region Tutorial
        public void KeyPressed(Image image, Sprite newIcon, LeanToggle leanToggle)
        {
            image.sprite = newIcon;
            leanToggle.On = true;
        }

        public void KeyReleased(LeanToggle leanToggle)
        {
            leanToggle.On = false;
        }
        #endregion

    }
}

