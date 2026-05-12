using UnityEngine;

public class GameStart : MonoBehaviour
{
    public CanvasGroup StartMenuCanvasGroup;
    private bool isGameStarted = false;

    public void Start()
    {
        CanvasGroupDisplayer.Show(StartMenuCanvasGroup);
    }
    
    public void OnStartButtonClicked()
    {
        CanvasGroupDisplayer.Hide(StartMenuCanvasGroup);
        isGameStarted = true;
    }
    
    
}