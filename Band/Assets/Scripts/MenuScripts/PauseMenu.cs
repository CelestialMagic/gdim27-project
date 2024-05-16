using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MenuNavigation
{
    [SerializeField]
    private GameObject pauseMenu;//A GameObject representing the Pause Menu

    private void Start()
    {
        UnpauseGame();
    }
    //The Update Method that checks for escape key (overrides MenuNavigation)
    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //If not paused, pause, and vice versa
            if (Time.timeScale == 1)
                PauseGame();
            else
                UnpauseGame();
        }
    }

    //Pauses the Game and Shows the Menu
    protected void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        GameStateManager.Paused();
    }

    //Unpauses the Game and Hides the Menu
    protected void UnpauseGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        GameStateManager.Game();
    }

    //Returns to Title and Unpauses the Game Scene (fixes time scale) 
    public override void GoToTitle()
    {
        UnpauseGame();
        GameStateManager.Menu();
        GameStateManager.ResetValues();
        SceneManager.LoadScene(titleScene);
        
    }
}
