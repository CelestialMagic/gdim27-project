using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    protected TMP_Text revenueText;

    [SerializeField]
    protected TMP_Text fanText;

    // Update is called once per frame
    protected virtual void Update()
    {
        fanText.text = $"Fans: {GameStateManager.GetFans()}";

        revenueText.text = $"Money: ${GameStateManager.GetMoney()}";
    }
}
