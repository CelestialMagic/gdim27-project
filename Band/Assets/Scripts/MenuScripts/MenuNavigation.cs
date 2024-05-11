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

    [SerializeField]
    private string highScore;

    protected virtual void Update()
    {

    }

    //Takes player to title screen when called
    public virtual void GoToTitle()
    {
        SceneManager.LoadScene(titleScene);
        GameStateManager.Menu();
    }

    //Takes player to game scene when called
    public virtual void GoToGameScene()
    {
        SceneManager.LoadScene(gameScene);
        GameStateManager.Game();
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
        GameStateManager.Menu();
    }

    public void GoToHighScore()
    {
        SceneManager.LoadScene(highScore);
        GameStateManager.Menu();
    }
}
