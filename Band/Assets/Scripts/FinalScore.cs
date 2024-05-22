using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    [SerializeField]
    private string mainMenu; 

    public void EndGame()
    {
        GameStateManager.SetFinalScore();
        SceneManager.LoadScene(mainMenu);
    }
}
