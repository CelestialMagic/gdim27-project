using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GigHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject gigUI;

    private Gig currentGig;

    [SerializeField]
    private TMP_Text gigText, gigName;

    public void CurrentGig(Gig gig)
    {
        gigUI.SetActive(true);
        currentGig = gig;
        //Assigns the current encounters values to Encounter UI
        gigText.text = currentGig.GetGigText();
        gigName.text = currentGig.GetGigName();
     

    }
}
