using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text revenueText;

    [SerializeField]
    private TMP_Text fanText;

    // Update is called once per frame
    void Update()
    {
        fanText.text = $"Fans: {GameStateManager.GetFans()}";

        revenueText.text = $"Money: ${GameStateManager.GetMoney()}";
    }
}
