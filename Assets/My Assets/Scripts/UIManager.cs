using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FruitDiet
{
    public class UIManager : MonoBehaviour
    {
        GameObject currentInterface;
        public void RepeatInteraction()
        {
            currentInterface.SetActive(true);
        }
        public void NextInteraction(GameObject nextInteraction)
        {
            currentInterface.SetActive(false);
            currentInterface = nextInteraction;
            currentInterface.SetActive(true);   
        }
    }
}

