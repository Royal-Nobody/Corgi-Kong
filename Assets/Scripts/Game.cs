using UnityEngine;

public class Game : MonoBehaviour
{
    public UI Ui;
    public FlySwatterPlacer FlySwatterPlacer;
    
    private bool isGameRunning = false;

    public void Start()
    {
        Ui.HideWinScreen();
        Ui.HideGameOverScreen();
        Ui.ShowStartScreen();
    }
    
    public bool IsPlaying()
    {
        return isGameRunning;
    }
    
    public void OnPlayButtonClicked()
    {
        Ui.HideStartScreen();
        InitializeGame();
    }

    public void InitializeGame()
    {
        isGameRunning = true;
        StartPlacers();
    }

    private void StartPlacers()
    {
        FlySwatterPlacer.StartPlacing();
    }

    private void StopPlacers()
    {
        FlySwatterPlacer.StopPlacing();
    }

    public void OnPlayAgainButtonClicked()
    {
        
    }
    
}
