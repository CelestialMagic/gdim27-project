using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigamePause : PauseMenu
{
    [SerializeField]
    private MiniGame_Player player;

    
    // Update is called once per frame
    protected override void Update()
    {
        if (player.GetCollided())
        {
            PauseGame();
        }
    }


    public override void GoToTitle()
    {
        GameStateManager.SetMoney(player.GetMinigameMoney());
        GameStateManager.SetFinalScore();
        SceneManager.LoadScene(titleScene);
    }
}
