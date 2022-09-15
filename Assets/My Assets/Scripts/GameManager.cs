using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitDiet
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [Header("References")]
        public InputManager inputInstance;
        public UIManager uiInstance;
        public DataManager dataInstance;
        public SceneManager sceneInstance;
        public SoundManager soundInstance;
        public StateMachine stateInstance;

        private void Awake()
        {
            //If there is an instance, and it's not me, delete myself.
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }

            inputInstance = GetComponent<InputManager>();
            uiInstance = GetComponent<UIManager>();
            dataInstance = GetComponent<DataManager>();
            sceneInstance = GetComponent<SceneManager>();
            soundInstance = GetComponent<SoundManager>();
            stateInstance = GetComponent<StateMachine>();
        }

        private void Update()
        {
            inputInstance.HandleAllInputs();
        }
    }
}


