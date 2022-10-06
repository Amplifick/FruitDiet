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

        public void DestroySelf()
        {

            StartCoroutine(DestroyItem());

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
                scenarioInstance.balanceValue += itemBalanceValue;
                scenarioInstance.GetNewMarkerPosition();
                scenarioInstance.spawnPositions[spawnPosIndex].hasItem = false;
                Destroy(gameObject);
            }
        }

    }
}

