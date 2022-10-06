using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;

namespace FruitDiet
{
    public class UI_Button : MonoBehaviour
    {
        [Header("Parameters")]
        public string sceneNameToLoad;

        private void Awake()
        {
            GameManager.Instance.uiInstance.AddLoadSceneFunctionToButton(GetComponent<LeanButton>(), sceneNameToLoad);
            GameManager.Instance.uiInstance.AddChangeStateOfGameFunctionToButton(GetComponent<LeanButton>(), StateOfGame.OnGame);
        }
    }
}
