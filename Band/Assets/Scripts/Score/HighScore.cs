using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HighScore : ScoreDisplay
{


    protected override void Update()
    {
        fanText.text = $"Fans: {GameStateManager.GetFinalFanScore()}";
        revenueText.text = $"Money: ${GameStateManager.GetFinalRevenueScore()}";
    }


}
