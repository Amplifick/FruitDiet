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

        private void Awake()
        {
            lastEndPosition = firstPlatforms.Find("EndPosition").position;
        }

        private void Update()
        {
            if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_PLATFORM)
            {
                //Spawn another platform
                SpawnPlatform();
            }
        }

        private void SpawnPlatform()
        {
            Transform platformTransform = SpawnPlatform(lastEndPosition);
            lastEndPosition = platformTransform.Find("EndPosition").position;
        }

        private Transform SpawnPlatform(Vector3 spawnPosition)
        {
            Transform platformTransform = Instantiate(platformPrefab,spawnPosition,Quaternion.identity, platformsParent);
            return platformTransform;
        }
    }
}

