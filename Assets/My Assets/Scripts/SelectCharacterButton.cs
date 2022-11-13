using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;
using FruitDiet;

public class SelectCharacterButton : MonoBehaviour
{
    [SerializeField] private LeanWindow myCharacterInfo;
    [SerializeField] private LeanWindow otherCharacterInfo;

    [SerializeField] private Sprite newContainerImage;
    [SerializeField] private LeanWindow characterUnlockedUI;

    public void EnableCharacterInfo()
    {
        if (!myCharacterInfo.On)
        {
            otherCharacterInfo.TurnOff();
            myCharacterInfo.TurnOn();    
        }

        //reproduce a sfx
    }

    public void BuyCharacter()
    {
        GetComponent<Image>().sprite = newContainerImage;
        GameManager.Instance.dataInstance.score.currentCalories -= 1000;
        characterUnlockedUI.TurnOn();
    }

    public void SelectCharacterToPlay()
    {
        //for now make the player go to play the game again
    }
}
