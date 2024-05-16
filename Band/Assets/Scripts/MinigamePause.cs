using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
