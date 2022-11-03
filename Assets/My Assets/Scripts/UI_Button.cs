using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Lean.Gui;

namespace FruitDiet
{
    public class UI_Button : MonoBehaviour
    {
        [Header("Parameters")]
        public string sceneNameToLoad;
        public AudioSource audioSource;
        public AudioClip audioClip;
        public float timeToEnableUI;
        public TMP_InputField inputField;

        [Header("Bools")]
        [SerializeField] private bool changeScene;
        [SerializeField] private bool changeToOnTutorialState, changeToOnGameState, changeToOnBossState;
        [SerializeField] private bool reloadScene;
        [SerializeField] private bool playSound;
        [SerializeField] private bool enableAfterTime;
        [SerializeField] private bool reloadSceneAndEnableInput;

        private void Awake()
        {
            if (changeScene)
                GameManager.Instance.uiInstance.AddLoadSceneFunctionToButton(GetComponent<LeanButton>(), sceneNameToLoad);

            if (changeToOnTutorialState)
                GameManager.Instance.uiInstance.AddChangeStateOfGameFunctionToButton(GetComponent<LeanButton>(), StateOfGame.OnTutorial);

            if (changeToOnGameState)
                GameManager.Instance.uiInstance.AddChangeStateOfGameFunctionToButton(GetComponent<LeanButton>(), StateOfGame.OnGame);

            if (changeToOnBossState)
                GameManager.Instance.uiInstance.AddChangeStateOfGameFunctionToButton(GetComponent<LeanButton>(), StateOfGame.OnBossFight);

            if (reloadScene)
                GameManager.Instance.uiInstance.AddReloadSceneFunctionToButton(GetComponent<LeanButton>());

            if (playSound)
                GameManager.Instance.uiInstance.AddPlayOneShotAudioFunctionToButton(GetComponent<LeanButton>(), audioSource, audioClip);

            if (enableAfterTime)
            {
                GameManager.Instance.uiInstance.EnableUIOnTime(GetComponent<CanvasGroup>(), timeToEnableUI);
            }

            if (reloadSceneAndEnableInput)
            {
                GameManager.Instance.uiInstance.AddReloadSceneAndEnableInputFunctionToButton(GetComponent<LeanButton>());
            }

        }

        public void CheckBeforeLoadingScene()
        {
            if (inputField.text != "")
            {
                GameManager.Instance.sceneInstance.LoadScene(sceneNameToLoad);
            }
        }

        public void CheckWASDBeforeLoadingScene()
        {
            UI_Key[] keys = FindObjectsOfType<UI_Key>();

            bool w = false, a = false, s = false, d = false;

            if (keys != null)
            {
                foreach (UI_Key key in keys)
                {
                    if (key.wPressed)
                    {
                        w = true;
                    }
                    if (key.aPressed)
                    {
                        a = true;
                    }
                    if (key.sPressed)
                    {
                        s = true;
                    }
                    if (key.dPressed)
                    {
                        d = true;
                    }
                }

                if (w && a && s && d)
                {
                    GameManager.Instance.sceneInstance.LoadScene(sceneNameToLoad);
                    GameManager.Instance.stateInstance.ChangeCurrentState(StateOfGame.OnGame);
                }

            }


        }

    }
}
