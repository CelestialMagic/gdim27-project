using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : Square
{
    //Creates four ints representing fans and money for A and B, respectively
    //Can be negative or positive, depending on the encounter
    [SerializeField]
    private int choiceAFans, choiceAMoney, choiceBFans, choiceBMoney;

    [SerializeField]
    private string encounterName, encounterText, choiceAText, choiceBText, choiceAFinish, choiceBFinish;

    //Called when player chooses the left choice.
    public void ChoiceA()
    {
        Debug.Log("Choice A");
        UpdateFans(choiceAFans);
        UpdateMoney(choiceAMoney);
    }

    //Called when player chooses the right choice.
    public void ChoiceB()
    {
        Debug.Log("Choice B");
        UpdateFans(choiceBFans);
        UpdateMoney(choiceBMoney);

    }

    public string GetEncounterName()
    {
        return encounterName;
    }

    public string GetEncounterText()
    {
        return encounterText;
    }


    public string GetChoiceAText()
    {
        return choiceAText;
    }

    public string GetChoiceBText()
    {
        return choiceBText;
    }

    public string GetChoiceAFinish()
    {
        return choiceAFinish;
    }

    public string GetChoiceBFinish()
    {
        return choiceBFinish;
    }


}
