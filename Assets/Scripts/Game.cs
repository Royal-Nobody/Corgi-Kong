using UnityEngine;

public class Game : MonoBehaviour
{
    public UI Ui;

    public bool isGameActive = false;
    
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
}
