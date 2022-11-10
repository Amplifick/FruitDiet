using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;

public class SelectCharacterButton : MonoBehaviour
{
    [SerializeField] private LeanWindow myCharacterInfo;
    [SerializeField] private LeanWindow otherCharacterInfo;

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
        //should be an interface for this new character
    }

    public void SelectCharacterToPlay()
    {
        //for now make the player go to play the game again
    }
}
