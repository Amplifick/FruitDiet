using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitDiet
{
    public class Item : Elements
    {
        [Header("Item Setting's")]
        [Tooltip("The amount that will be added or substracted from the balance bar")]
        public float balanceAmount;

        private void OnTriggerEnter(Collider other)
        {
            
        }
    }
}

