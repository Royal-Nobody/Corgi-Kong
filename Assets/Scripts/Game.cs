using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
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
        HideMouseCursor();
        isGameActive = true;
        Ui.HideStartScreen();
    }

    public void TriggerGameOver()
    {
        ShowMouseCursor();
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
        HideMouseCursor();
        ResetGame();
        Ui.HideGameOverScreen();
        Ui.HideWinScreen();
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
        HideMouseCursor();
        ClearMap();
        isGameActive = true;
    }

    public GameObject[] ActiveSpiders()
    {
        return GameObject.FindGameObjectsWithTag("Spider");
    }
    
    public void HideMouseCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
