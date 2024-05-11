using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Square : MonoBehaviour
{

    [SerializeField]
    private bool isEncounter;//A serializable bool representing if a square is an encounter

    [SerializeField]
    private bool isGig;//A serializable bool representing if a square is a gig

    [SerializeField]
    private int encounterNum;

    //SetEncounter() allows another class to assign an encounter to a square
    public void SetMyEncounter(int number)
    {
        encounterNum = number; 
    }


    public int GetMyEncounter()
    {
        return encounterNum;
    }

    //GetIsEncounter() returns the bool value isEncounter
    public bool GetIsEncounter()
    {
        return isEncounter; 
    }

    //GetIsGig() returns the bool value isGig
    public bool GetIsGig()
    {
        return isGig;
    }

    //Calls GameStateManager to update global fans
    protected virtual void UpdateFans(int fans)
    {
        GameStateManager.SetFans(fans);
    }

    //Calls GameStateManager to update global money
    protected virtual void UpdateMoney(int money)
    {
        GameStateManager.SetFans(money);
    }
}
