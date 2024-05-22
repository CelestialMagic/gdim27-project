using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneChoiceEncounter : Square
{
    [SerializeField]
    protected SpriteRenderer icon;

    [SerializeField]
    protected Color inactiveColor;
    //Creates four ints representing fans and money for A and B, respectively
    //Can be negative or positive, depending on the encounter
    [SerializeField]
    protected int choiceAFans, choiceAMoney;

    [SerializeField]
    protected string encounterName, choiceAText;

    [TextArea(15, 20)]
    [SerializeField]
    protected string encounterText, choiceAFinish;

    //Called when player chooses the left choice.
    public void ChoiceA()
    {
        Debug.Log("Choice A");
        GameStateManager.SetFans(choiceAFans);
        GameStateManager.SetMoney(choiceAMoney);
    }


    //Sets an Encounter as inactive after being experienced 
    public void InactiveEncounter()
    {
        gameObject.tag = "Inactive";
        icon.color = inactiveColor;

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

    public string GetChoiceAFinish()
    {
        return choiceAFinish;
    }

}
