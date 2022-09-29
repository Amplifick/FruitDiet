using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;


namespace FruitDiet
{
    public class UIManager : MonoBehaviour
    {

        GameObject currentInterface;
        public void RepeatInteraction()
        {
            currentInterface.SetActive(true);
        }

        public void NextInteraction(GameObject nextInteraction)
        {
            currentInterface.SetActive(false);
            currentInterface = nextInteraction;
            currentInterface.SetActive(true);   
        }


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

