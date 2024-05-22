using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gig : Square
{
    [SerializeField]
    private string gigName, optionAText, optionBText;

    [TextArea(15, 20)]
    [SerializeField]
    private string gigText, gigChoiceText, optionAEpilogue, optionBEpilogue;

    [SerializeField]
    private int optionAMoney, optionAFans, optionBMoney, optionBFans;


    public string GetGigName()
    {
        return gigName;
    }

    public string GetGigText()
    {
        return gigText;
    }

    public string GetGigChoiceText()
    {
        return gigChoiceText;
    }


    public string GetOptionAText()
    {
        return optionAText;
    }

    public string GetOptionAEpilogue()
    {
        return optionAEpilogue;
    }

    public string GetOptionBText()
    {
        return optionBText;
    }

    public string GetOptionBEpilogue()
    {
        return optionBEpilogue;
    }

    public int GetOptionAMoney()
    {
        return optionAMoney;
    }

    public int GetOptionAFans()
    {
        return optionAFans;
    }

    public int GetOptionBMoney()
    {
        return optionBMoney;
    }

    public int GetOptionBFans()
    {
        return optionBFans;
    }
}
