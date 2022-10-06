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

        public void AddChangeStateOfGameFunctionToButton(LeanButton leanButton, StateOfGame newStateOfGame)
        {
            leanButton.OnClick.AddListener(() =>
            {
                GameManager.Instance.stateInstance.ChangeCurrentState(newStateOfGame);
            });
        }


        #endregion

        #region Tutorial
        public void KeyPressed(Image image, Sprite newIcon, GameObject outlineVFX, LeanToggle leanToggle)
        {
            image.sprite = newIcon;
            leanToggle.On = true;
            if (outlineVFX)
                outlineVFX.SetActive(true);
        }

        public void KeyReleased(Image image, Sprite newIcon, GameObject outlineVFX, LeanToggle leanToggle)
        {
            image.sprite = newIcon;
            leanToggle.On = false;
            if (outlineVFX)
                outlineVFX.SetActive(false);
        }
        #endregion

    }
}

