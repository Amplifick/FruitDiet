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
        public AudioSource audioSource;
        public AudioClip audioClip;

        [Header("Bools")]
        [SerializeField] private bool changeScene;
        [SerializeField] private bool changeToOnGameState;
        [SerializeField] private bool reloadScene;
        [SerializeField] private bool playSound;

        private void Awake()
        {
            if (changeScene)
                GameManager.Instance.uiInstance.AddLoadSceneFunctionToButton(GetComponent<LeanButton>(), sceneNameToLoad);

            if (changeToOnGameState)
                GameManager.Instance.uiInstance.AddChangeStateOfGameFunctionToButton(GetComponent<LeanButton>(), StateOfGame.OnGame);

            if (reloadScene)
                GameManager.Instance.uiInstance.AddReloadSceneFunctionToButton(GetComponent<LeanButton>());

            if (playSound)
                GameManager.Instance.uiInstance.AddPlayOneShotAudioFunctionToButton(GetComponent<LeanButton>(), audioSource, audioClip);
        }
    }
}
