using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitDiet
{
    public class Scenario : MonoBehaviour
    {
        private const float PLAYER_DISTANCE_SPAWN = 20f;

        [Header("Balance Bar Settings")]
        [Tooltip("The marker on the UI that indicates the player currrent balance on the balance bar")]
        public RectTransform markerTransform;
        [Tooltip("The current amount of balance. This changes when the player recolects an item")]
        public float balanceValue = 0;

        [Header("Level Generation Setting's")]
        [SerializeField] private Player player;
        [SerializeField] private Transform platformsParent;
        [SerializeField] private Transform firstPlatform;
        [SerializeField] private Transform platformPrefab;
        private Vector3 lastEndPosition;

        [Header("Item Spawn Settings")]
        public Item[] foodPrefabs;
        public SpawnPosition[] spawnPositions;
        public Transform itemsParent;
        [Tooltip("This will handle the spawning rate when we are fighting against the boss")]
        public float spawningRate;

        [Header("Level Settings")]
        [SerializeField] private float timeTheRoundLasts;
        private float currentTime;

        [Header("UI Elements")]
        public GameObject greenOverlay;
        public GameObject yellowOverlay;
        public GameObject loseUI;
        public GameObject winUI;

        [Header("Sounds")]
        [SerializeField] private AudioClip loseAudioClip;
        [SerializeField] private AudioClip winAudioClip;
        [SerializeField] private bool canPlay;
        [SerializeField] private bool hasWon;


        private void Awake()
        {
            if (GameManager.Instance.stateInstance.currentState == StateOfGame.OnBossFight)
                return;

            lastEndPosition = firstPlatform.Find("EndPosition").position;
        }

        private void Start()
        {
            if (GameManager.Instance.stateInstance.currentState == StateOfGame.OnBossFight)
                return;

            InvokeRepeating(nameof(SpawnItem), 1f, spawningRate);
        }

        private void Update()
        {
            if (!canPlay)
                return;

            if (!hasWon)
                WinLevelCheck();

            if (GameManager.Instance.stateInstance.currentState == StateOfGame.OnBossFight)
                return;

            if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN)
            {
                //Spawn another platform
                SpawnPlatform();
            }
        }

        public void GetNewMarkerPosition()
        {
            balanceValue = Mathf.Clamp(balanceValue, -600f, 600f);
            Vector3 newPos = new Vector3(balanceValue, 0f, 0f);

            GameManager.Instance.uiInstance.UpdateMarkerPosition(markerTransform, newPos);

            if (balanceValue == -600 || balanceValue == 600)
            {
                if (canPlay)
                {
                    GameManager.Instance.uiInstance.EnableUIElement(loseUI);
                    GameManager.Instance.soundInstance.SetAudioVolume(FindObjectOfType<AudioSource>(), 0.035f);
                    GameManager.Instance.soundInstance.PlaySoundOneShot(loseAudioClip);
                    GameManager.Instance.inputInstance.canMove = false;
                    canPlay = false;
                    return;
                }

            }

            if (balanceValue < -400)
            {
                GameManager.Instance.uiInstance.EnableUIElement(yellowOverlay);
            }
            else
            {
                GameManager.Instance.uiInstance.DisableUIElement(yellowOverlay);
            }
            if (balanceValue > 400)
            {
                GameManager.Instance.uiInstance.EnableUIElement(greenOverlay);
            }
            else
            {
                GameManager.Instance.uiInstance.DisableUIElement(greenOverlay);
            }


        }

        #region Platform Functions

        private void SpawnPlatform()
        {
            Transform platformTransform = SpawnPlatform(lastEndPosition);
            lastEndPosition = platformTransform.Find("EndPosition").position;
        }

        private Transform SpawnPlatform(Vector3 spawnPosition)
        {
            Transform platformTransform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity, platformsParent);
            return platformTransform;
        }

        #endregion

        #region Item Functions

        private void SpawnItem()
        {
            bool freePositions = false;

            foreach (SpawnPosition spawnPosition in spawnPositions)
            {
                if (!spawnPosition.hasItem)
                    freePositions = true;
            }

            if (!freePositions)
                return;

            int random = Random.Range(0, foodPrefabs.Length);

            int randomPos = Random.Range(0, spawnPositions.Length);

            while (spawnPositions[randomPos].hasItem)
            {
                randomPos = Random.Range(0, spawnPositions.Length);
            }

            Item item = Instantiate(foodPrefabs[random], spawnPositions[randomPos].transform.position, Quaternion.identity, itemsParent);
            item.spawnPosIndex = randomPos;
            spawnPositions[randomPos].hasItem = true;
            item.DestroySelf();
        }

        #endregion

        #region Win level Functions

        private void WinLevelCheck()
        {
            currentTime += Time.deltaTime;

            if (currentTime >= timeTheRoundLasts)
            {
                hasWon = true;
                GameManager.Instance.uiInstance.EnableUIElement(winUI);
                GameManager.Instance.sceneInstance.PauseGame();
                GameManager.Instance.soundInstance.SetAudioVolume(FindObjectOfType<AudioSource>(), 0.035f);
                GameManager.Instance.soundInstance.PlaySoundOneShot(winAudioClip);
                GameManager.Instance.inputInstance.canMove = true;
            }

        }

        #endregion
    }
}

