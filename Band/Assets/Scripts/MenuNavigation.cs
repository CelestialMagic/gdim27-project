using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    [SerializeField]
    protected string gameScene;//a string representing the game scene

    [SerializeField]
    protected string titleScene;//a string representing the title screen

    [SerializeField]
    private string tutorialScene;//a string representing the tutorial scene

    protected virtual void Update()
    {

    }

    //Takes player to title screen when called
    public virtual void GoToTitle()
    {
        SceneManager.LoadScene(titleScene);
    }

    //Takes player to game scene when called
    public virtual void GoToGameScene()
    {
        SceneManager.LoadScene(gameScene);
    }

    //Quits the game
    public void QuitGame()
    {
        Application.Quit(); 
    }

    //Takes player to tutorial scene 
    public void GoToTutorial()
    {
        SceneManager.LoadScene(tutorialScene);
    }
}
