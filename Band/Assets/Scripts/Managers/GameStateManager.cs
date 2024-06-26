using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private static GAMESTATE state; //The current game state

    private static GameStateManager _instance; //This class is a Singleton - We will also discuss this pattern later in this class.

    private static int fans, money, finalFanScore, finalRevenueScore; //Represents the fan and revenue counts

    private static string gigText, gigChoiceA, gigChoiceB; 

    //An enum that represents the game states. 
    enum GAMESTATE
    {
        MENU,
        PLAYING,
        PAUSED,
        GAMEOVER,

    }



    // Start is called before the first frame update
    void Start()
    {
        //Singleton Code
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(_instance);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }

        state = GAMESTATE.MENU;
        ResetValues();

    }

    private void Update()
    {
 
    }

    //Updates game state to menu
    public static void Menu()
    {
        state = GAMESTATE.MENU;
    }

    //Updates game state to playing game
    public static void Game()
    {
        state = GAMESTATE.PLAYING;
    }

    //Updates game state to paused
    public static void Paused()
    {
        state = GAMESTATE.PAUSED;
    }

    //Gets the fans 
    public static int GetFans()
    {
        return fans;
    }

    //Sets the fans
    public static void SetFans(int amount)
    {
        if (fans + amount <= 0)
            fans = 0;
        else
            fans += amount;
    }

    //Gets the money
    public static int GetMoney()
    {
        return money;
    }

    //Sets the money
    public static void SetMoney(int amount)
    {
        money += amount;
    }

    //Resets the game values 
    public static void ResetValues()
    {
        money = 500;
        fans = 0;
    }

    //Used to set the high score 
    public static void SetFinalScore()
    {
        if(money > PlayerPrefs.GetInt("FinalRevenue") && fans > PlayerPrefs.GetInt("FinalFans"))
        {
            PlayerPrefs.SetInt("FinalRevenue", money);
            PlayerPrefs.SetInt("FinalFans", fans);
        }
  

    }

    //Used to retrieve current final score and final fans 
    public static int GetFinalFanScore()
    {
        return PlayerPrefs.GetInt("FinalFans");
    }

    public static int GetFinalRevenueScore()
    {
        return PlayerPrefs.GetInt("FinalRevenue");
    }


}
