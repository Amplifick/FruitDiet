using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitDiet
{
    public class Item : Elements
    {
        [Header("Item Setting's")]
        [Tooltip("The amount that will be added or substracted from the balance bar")]
        public float itemBalanceValue;
        public int spawnPosIndex;
        public float moveSpeed = 0;
        [HideInInspector] public Transform targetToMove;

        private void Update()
        {
            if (moveSpeed > 0)
                transform.position = Vector3.MoveTowards(transform.position, targetToMove.position, Time.deltaTime * moveSpeed);
        }

        public void DestroySelf()
        {
            StartCoroutine(DestroyItem());
        }

        public void DestroyOnBossFight()
        {
            StartCoroutine(DestroyItemBoss());
        }

        private IEnumerator DestroyItemBoss()
        {
            yield return new WaitForSeconds(8f);
            Destroy(gameObject);
        }

        private IEnumerator DestroyItem()
        {
            yield return new WaitForSeconds(8f);
            scenarioInstance.spawnPositions[spawnPosIndex].hasItem = false;
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (!scenarioInstance.canPlay)
                    return;

                scenarioInstance.balanceValue += itemBalanceValue;
                scenarioInstance.GetNewMarkerPosition();
                scenarioInstance.PlayBalanceBarPulse();

                if (GameManager.Instance.stateInstance.currentState != StateOfGame.OnBossFight)
                    scenarioInstance.spawnPositions[spawnPosIndex].hasItem = false;


                GameManager.Instance.soundInstance.PlaySoundOneShot(GameManager.Instance.soundInstance.bankOfAudios[1].sound,.2f);
                Destroy(gameObject);
            }
        }

    }
}

