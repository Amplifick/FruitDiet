using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitDiet
{
    public class Elements : MonoBehaviour
    {
        [Header("References")]
        private Scenario scenarioInstance;

        private void Awake()
        {
            scenarioInstance = FindObjectOfType<Scenario>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                scenarioInstance.GetNewMarkerPosition();
                Destroy(gameObject);
            }
        }

    }
}

