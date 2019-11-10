using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button BtnStartGame;
    public Button BtnRewards;
    public Button BtnSettings;
    

    public void StartGame()
    {
        //SceneManager.LoadScene(/*"Game"*/0);
        Debug.Log("START GAME!");
    }

    public void LoadRewards()
    {
        Debug.Log("load reward");
    }

    public void LoadSettingsPanel()
    {
        Debug.Log("load settings panel");
    }
}
