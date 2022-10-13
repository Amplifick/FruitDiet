using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitDiet
{
    public class Elements : MonoBehaviour
    {
        [Header("References")]
        [HideInInspector] public Scenario scenarioInstance;

        private void Awake()
        {
            scenarioInstance = FindObjectOfType<Scenario>();
        }


    }
}

