using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitDiet
{
    public enum StateOfGame
    {
        OnMenu,
        OnTutorial,
        OnGame,
        OnBossFight,
    }
    public class StateMachine : MonoBehaviour
    {
        [Header("Parameters")]
        public StateOfGame currentState;

        public void ChangeCurrentState(StateOfGame newStateOfGame)
        {
            currentState = newStateOfGame;
        }
    }
}

