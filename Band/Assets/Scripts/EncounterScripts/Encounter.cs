using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : OneChoiceEncounter
{
    //Derives from one choice encounter and adds an additional choice 
    [SerializeField]
    private int choiceBFans, choiceBMoney;

    [SerializeField]
    private string choiceBText;

    [TextArea(15, 20)]
    [SerializeField]
    private string choiceBFinish;

    //Called when player chooses the right choice.
    public void ChoiceB()
    {
        Debug.Log("Choice B");
        GameStateManager.SetFans(choiceBFans);
        GameStateManager.SetMoney(choiceBMoney);

    }

    public string GetChoiceBText()
    {
        return choiceBText;
    }

    public string GetChoiceBFinish()
    {
        return choiceBFinish;
    }


}
