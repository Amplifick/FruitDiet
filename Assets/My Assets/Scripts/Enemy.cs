using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitDiet
{
    [System.Serializable]
    public class FoodBossFight
    {
        public Item pfItem;
        [Tooltip("min and max % of probs to be spawned. Be aware the sum of the 4 items must be 100")]
        public float minOddsToSpawn;
        public float maxOddsToSpawn;
    }

    public class Enemy : CharacterController
    {
        [Header("Power Up Settings")]
        [SerializeField] private bool canUsePower;
        [SerializeField] private bool isOnPower;
        [SerializeField] private float currentPowerCooldown;
        [SerializeField] private float powerCooldown;
        [SerializeField] private float currentPowerTimer;
        [SerializeField] private float powerDuration;
        [SerializeField] private float normalMoveSpeed;
        [SerializeField] private float onPowerMoveSpeed;

        [Header("Spawn Settings")]
        [SerializeField] private float spawnRate;
        [SerializeField] private List<Transform> spawnPositions = new();
        [SerializeField] private List<FoodBossFight> items = new();
        [SerializeField] private Transform targetItemPosition;
        [SerializeField] private Transform itemsParent;


        private void Start()
        {
            InvokeRepeating(nameof(SpawnItems), 1f, spawnRate);
        }

        private void Update()
        {
            if (canUsePower)
            {
                canUsePower = false;
                anim.SetTrigger("usePower");
                CancelInvoke();
                isOnPower = true;
                //spawnRate = spawnRate * 2f;
                InvokeRepeating(nameof(SpawnItems), 0f, spawnRate);
            }

            if (isOnPower)
            {
                currentPowerTimer -= Time.deltaTime;

                if (currentPowerTimer <= 0)
                {
                    CancelInvoke();
                    isOnPower = false;
                    //spawnRate = spawnRate;
                    InvokeRepeating(nameof(SpawnItems), 0f, spawnRate);
                    currentPowerTimer = powerDuration;
                    currentPowerCooldown = powerCooldown;
                }
            }


            if(currentPowerCooldown > 0)
            {
                currentPowerCooldown -= Time.deltaTime;
            }
            else
            {
                canUsePower = true;
            }
        }

        private void SpawnItems()
        {
            int random = Random.Range(0, 101);
            int randomSpawn = Random.Range(0, spawnPositions.Count);

            foreach (var item in items)
            {
                if (random >= item.minOddsToSpawn && random <= item.maxOddsToSpawn)
                {
                    Item insItem = Instantiate(item.pfItem, spawnPositions[randomSpawn].transform.position, Quaternion.identity, itemsParent);
                    insItem.targetToMove = targetItemPosition;
                    if (isOnPower)
                        insItem.moveSpeed = onPowerMoveSpeed;
                    else
                        insItem.moveSpeed = normalMoveSpeed;

                    insItem.DestroyOnBossFight();
                }
            }
        }
    }
}

