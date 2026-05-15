using System.Collections.Generic;
using Unity.VectorGraphics;
using Unity.VisualScripting;
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
    public bool allowSpiderSpawning = false;

    public Music Music;
    public Cutscene cutscene;

    public void Start()
    {
        Music.PlayThemeMusic();
    }
    
    public void OnPlayButtonClicked()
    {
        HideMouseCursor();
        cutscene.PlayIntroCutscene();
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
        ShowMouseCursor();
        isGameActive = false;
        Ui.ShowWinScreen();
    }

    public void PlayAgainButtonClicked()
    {
        HideMouseCursor();
        ResetGame();
        isGameActive = false;
        cutscene.PlayIntroCutscene();
        Ui.HideGameOverScreen();
        Ui.HideWinScreen();
    }

    public void RestartGameClearMap()
    {
        foreach (GameObject spider in AllActiveSpiders())
        {
            Destroy(spider);
        }
        
        playerObject.transform.position = playerStartLocation.position;
    }
    
    public void ClearMap()
    {
        foreach (GameObject spider in ActiveSpidersToKill())
        {
            Destroy(spider);
        }
        
        playerObject.transform.position = playerStartLocation.position;
        
    }

    public void ResetGame()
    {
        HideMouseCursor();
        RestartGameClearMap();
    }

    public GameObject[] ActiveSpidersToKill()
    {
        return GameObject.FindGameObjectsWithTag("Destroy This Spider");
    }
    
    public GameObject[] AllActiveSpiders()
    {
        List<GameObject> spiders = new List<GameObject>();
        
        spiders.AddRange(GameObject.FindGameObjectsWithTag("Destroy This Spider"));
        spiders.AddRange(GameObject.FindGameObjectsWithTag("Spider"));
        
        return spiders.ToArray();
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
