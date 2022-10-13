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

        [Space]
        [Header("Camera Follow Settings")]
        public float followSpeed = 2f;
        public float yOffSet = 2f;
        public Transform target;
        private Camera mainCamera;

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
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }

            if (target != null)
            {
                Vector3 newPos = new Vector3(target.position.x, 0f, -10f);
                mainCamera.transform.position = Vector3.Slerp(mainCamera.transform.position, newPos, followSpeed * Time.deltaTime);
            }
            else
            {
                if (stateInstance.currentState == StateOfGame.OnGame)
                {
                    target = FindObjectOfType<Player>().transform;
                }
            }

            inputInstance.HandleAllInputs();

        }
    }
}


