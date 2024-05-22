using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinalGigHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject mainChoiceUI, epilogueUI;

    [SerializeField]
    private Button finalA, finalB, epilogueButton;

    [SerializeField]
    private TMP_Text finalText, aChoice, bChoice, epilogue;

    // Start is called before the first frame update
    void Start()
    {
        finalText.text = GameStateManager.GetGigText();
        aChoice.text = GameStateManager.GetGigChoiceA();
        bChoice.text = GameStateManager.GetGigChoiceB();
    }

    public void SelectedChoiceA()
    {
        GameStateManager.SetFans(GameStateManager.GetAFans());
        GameStateManager.SetMoney(GameStateManager.GetAMoney());
        UnsubscribeButtons();
        DeactivateChoiceMenu();
        ActivateEpilogueMenu();
        epilogue.text = GameStateManager.GetEndingA();
    }

    //Carries out logic based on choice made
    public void SelectedChoiceB()
    {
        GameStateManager.SetFans(GameStateManager.GetBFans());
        GameStateManager.SetMoney(GameStateManager.GetBMoney());
        UnsubscribeButtons();
        DeactivateChoiceMenu();
        ActivateEpilogueMenu();
        epilogue.text = GameStateManager.GetEndingB();

    }

    //Removes button from having same choices as before
    public void UnsubscribeButtons()
    {
        finalA.onClick.RemoveAllListeners();
        finalB.onClick.RemoveAllListeners();
    }

    //Deactivates EncounterUI
    public void DeactivateChoiceMenu()
    {
        mainChoiceUI.SetActive(false);
    }

    //Deactivates AfterChoiceUI
    public void DeactivateEpilogueMenu()
    {
        epilogueUI.SetActive(false);
    }

    //Activates the AfterChoiceUI
    public void ActivateEpilogueMenu()
    {
        epilogueUI.SetActive(true);
    }
}
