using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : Square
{
    //Creates four ints representing fans and money for A and B, respectively
    //Can be negative or positive, depending on the encounter
    [SerializeField]
    private int choiceAFans, choiceAMoney, choiceBFans, choiceBMoney;

    //Called when player chooses the left choice.
    public void ChoiceA()
    {
        UpdateFans(choiceAFans);
        UpdateMoney(choiceAMoney);
    }

    //Called when player chooses the right choice.
    public void ChoiceB()
    {
        UpdateFans(choiceBFans);
        UpdateMoney(choiceBMoney);

    }
}
