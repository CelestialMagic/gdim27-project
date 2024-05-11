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

    [SerializeField]
    private GameObject afterChoiceUI;

    //Text used by the Encounter UI
    [SerializeField]
    private TMP_Text encounterTitle, encounterText, choiceAText, choiceBText, epilogue;

    //Buttons used by the Encounter UI
    [SerializeField]
    private Button choiceAButton, choiceBButton;

    private Encounter currentEncounter;//An encounter representing the current collided 

    //Sets the Encounter UI based on current encounter
    public void CurrentEncounter(Encounter encounter)
    {
        encounterUI.SetActive(true);
        currentEncounter = encounter;
        //Assigns the current encounters values to Encounter UI
        encounterTitle.text = currentEncounter.GetEncounterName();
        encounterText.text = currentEncounter.GetEncounterText();
        choiceAText.text = currentEncounter.GetChoiceAText();
        choiceBText.text = currentEncounter.GetChoiceBText();

        //Adds a listener to button based on Encounter 
        choiceAButton.onClick.AddListener(delegate { currentEncounter.ChoiceA(); });
        choiceBButton.onClick.AddListener(delegate { currentEncounter.ChoiceB(); });

    }

    //Carries out logic based on choice made 
    public void SelectedChoiceA()
    {
        UnsubscribeButtons();
        DeactivateEncounterMenu();
        ActivateAfterMenu();
        epilogue.text = currentEncounter.GetChoiceAFinish();
    }

    //Carries out logic based on choice made
    public void SelectedChoiceB()
    {
        UnsubscribeButtons();
        DeactivateEncounterMenu();
        ActivateAfterMenu();
        epilogue.text = currentEncounter.GetChoiceBFinish();

    }

    //Removes button from having same choices as before
    public void UnsubscribeButtons()
    {
        choiceAButton.onClick.RemoveAllListeners();
        choiceBButton.onClick.RemoveAllListeners();
    }

    //Deactivates EncounterUI
    public void DeactivateEncounterMenu()
    {
        encounterUI.SetActive(false);
    }

    //Deactivates AfterChoiceUI
    public void DeactivateAfterMenu()
    {
        afterChoiceUI.SetActive(false);
    }

    //Activates the AfterChoiceUI
    public void ActivateAfterMenu()
    {
        afterChoiceUI.SetActive(true);
    }

}
