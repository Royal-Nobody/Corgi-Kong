using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public UI Ui;

    public Transform playerStartLocation;

    public GameObject playerObject;
    
    public bool isGameActive = false;

    public Music Music;

    public void Start()
    {
        Music.PlayThemeMusic();
    }
    
    public void OnPlayButtonClicked()
    {
        isGameActive = true;
        Ui.HideStartScreen();
    }

    public void TriggerGameOver()
    {
        isGameActive = false;
        Ui.ShowGameOverScreen();
    }
    public void TriggerWinScreen()
    {
        isGameActive = false;
        Ui.ShowWinScreen();
    }

    public void PlayAgainButtonClicked()
    {
        ResetGame();
        Ui.HideGameOverScreen();
    }

    public void ClearMap()
    {
        foreach (GameObject spider in ActiveSpiders())
        {
            Destroy(spider);
        }
        
        playerObject.transform.position = playerStartLocation.position;
        
    }

    public void ResetGame()
    {
        ClearMap();
        isGameActive = true;
    }

    public GameObject[] ActiveSpiders()
    {
        return GameObject.FindGameObjectsWithTag("Spider");
    }
}
