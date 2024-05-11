using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Acts as a way to call GameStateManager, even when it is not in scene 
public class GSMBackUp : MonoBehaviour
{
    public void SetMenuState()
    {
        GameStateManager.Menu();
    }

    public void SetPlayingState()
    {
        GameStateManager.Game();
    }

    public void SetPausedState()
    {
        GameStateManager.Paused();
    }
        
}
