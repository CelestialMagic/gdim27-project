using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PauseMenu : MenuNavigation
{
    [SerializeField]
    private GameObject pauseMenu;

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
                PauseGame();
            else
                UnpauseGame();
        }
    }


    private void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public override void GoToTitle()
    {
        UnpauseGame();
        SceneManager.LoadScene(titleScene);
    }
}
