using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    [SerializeField]
    private string gameScene;//a string representing the game scene

    [SerializeField]
    private string titleScene;//a string representing the title screen

    //Takes player to title screen when called
    public void GoToTitle()
    {
        SceneManager.LoadScene(titleScene);
    }

    //Takes player to game scene when called
    public void GoToGameScene()
    {
        SceneManager.LoadScene(gameScene);
    }

    //Quits the game
    public void QuitGame()
    {
        Application.Quit(); 
    }
}
