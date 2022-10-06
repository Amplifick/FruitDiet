using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitDiet
{
    public class Scenario : MonoBehaviour
    {
        [Header("Level Generation Setting's")]
        private const float PLAYER_DISTANCE_SPAWN_PLATFORM = 20f;
        [SerializeField] private Player player;
        [SerializeField] private Transform platformsParent;
        [SerializeField] private Transform firstPlatforms;
        [SerializeField] private Transform platformPrefab;
        private Vector3 lastEndPosition;

        [Header("Balance Bar Settings")]
        public RectTransform markerTransform;
        public float balanceValue = 0;

        private void Awake()
        {
            lastEndPosition = firstPlatforms.Find("EndPosition").position;
        }

        private void Update()
        {
            balanceValue = Mathf.Clamp(balanceValue, -600f, 600f);

            if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_PLATFORM)
            {
                //Spawn another platform
                SpawnPlatform();
            }
        }

        public void GetNewMarkerPosition()
        {
            Vector3 newPos = new Vector3(balanceValue, 0f, 0f);

            GameManager.Instance.uiInstance.UpdateMarkerPosition(markerTransform, newPos);

            if(balanceValue < -400)
            {
                //activar overlay dependiende de su opacidad
                //esto se llama desde uiManager
            }
            else
            {
                //desactivar overlay
            }
            if (balanceValue > 400)
            {
                //activar overlay dependiende de su opacidad
            }
            else
            {
                //desactivar overlay
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
    }
}

