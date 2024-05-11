using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EncounterHandler : MonoBehaviour
{
    //The GameObject containing the Encounter UI
    [SerializeField]
    private GameObject encounterUI;

    //Text used by the Encounter UI
    [SerializeField]
    private TMP_Text encounterTitle, encounterText, choiceAText, choiceBText;

    //Buttons used by the Encounter UI
    [SerializeField]
    private Button choiceAButton, choiceBButton;

    //Sets the Encounter UI based on current encounter
    public void CurrentEncounter(Encounter encounter)
    {
        encounterUI.SetActive(true);

        //Assigns the current encounters values to Encounter UI
        encounterTitle.text = encounter.GetEncounterName();
        encounterText.text = encounter.GetEncounterText();
        choiceAText.text = encounter.GetChoiceAText();
        choiceBText.text = encounter.GetChoiceBText();

        //Adds a listener to button based on Encounter 
        choiceAButton.onClick.AddListener(delegate { encounter.ChoiceA(); });
        choiceAButton.onClick.AddListener(delegate { encounter.ChoiceB(); });

    }
}
