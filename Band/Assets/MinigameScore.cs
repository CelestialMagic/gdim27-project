using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameScore : ScoreDisplay
{
    [SerializeField]
    private MiniGame_Player player; 
    // Update is called once per frame
    protected override void Update()
    {
        revenueText.text = $"Earned Money: ${ player.GetMinigameMoney()}";
    }
}
