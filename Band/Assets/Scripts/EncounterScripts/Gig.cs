using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gig : Square
{
    [SerializeField]
    private string gigName, gigText;


    public string GetGigName()
    {
        return gigName;
    }

    public string GetGigText()
    {
        return gigText;
    }

}
