using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{

    [SerializeField]
    private bool isEncounter;//A serializable bool representing if a square is an encounter

    [SerializeField]
    private bool isGig;//A serializable bool representing if a square is a gig


    //SetEncounter() allows another class to assign an encounter to a square
    public void SetEncounter()
    {

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
}
